using System;
using System.Threading.Tasks;
using MasjidOnline.Business.Authorization.Interface;
using MasjidOnline.Business.Donation.Interface.Donation;
using MasjidOnline.Business.Model.Donation.Donation;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Data.Interface;
using MasjidOnline.Entity.Approval;
using MasjidOnline.Service.Interface;

namespace MasjidOnline.Business.Donation.Donation;

public class ApproveSuccessBusiness(IAuthorizationBusiness _authorizationBusiness, IService _service) : IApproveSuccessBusiness
{
    public async Task<Response> ApproveAsync(Model.Session.Session session, IData _data, ApproveSuccessRequest approveSuccessRequest)
    {
        await _authorizationBusiness.Donation.Donation.AuthorizeRequestFailAync(session, _data);

        approveSuccessRequest = _service.FieldValidator.ValidateRequired(approveSuccessRequest);

        approveSuccessRequest.Id = _service.FieldValidator.ValidateRequiredPlus(approveSuccessRequest.Id);

        var donationStatus = await _data.Donation.Donation.GetStatusAsync(approveSuccessRequest.Id.Value);

        if (donationStatus != Entity.Donation.DonationStatus.SuccessRequest) return new()
        {
            ResultCode = ResponseResultCode.InputMismatch,
            ResultMessage = $"Status: {donationStatus}",
        };

        var approvalId = await _data.Approval.Approval.GetIdAsync(ApprovalType.Donation, approveSuccessRequest.Id.Value);

        if (approvalId == default) return new()
        {
            ResultCode = ResponseResultCode.DataMismatch,
            ResultMessage = $"Status: {donationStatus}",
        };

        await _data.Transaction.BeginAsync(_data.Approval, _data.Donation, _data.Payment);

        _data.Donation.Donation.SetStatus(approveSuccessRequest.Id.Value, Entity.Donation.DonationStatus.Success);

        _data.Payment.Payment.SetStatus(approveSuccessRequest.Id.Value, Entity.Payment.PaymentStatus.Success);

        await _data.Approval.Approval.SetStatusAsync(approvalId, 1, ApprovalStatus.Approve);

        var approvalStep = new ApprovalStep
        {
            ApprovalId = approvalId,
            DateTime = DateTime.UtcNow,
            Id = _data.IdGenerator.Approval.ApprovalStepId,
            Status = ApprovalStatus.Approve,
            Step = 1,
            UserId = session.UserId,
        };

        await _data.Approval.ApprovalStep.AddAsync(approvalStep);

        await _data.Transaction.CommitAsync();

        return new()
        {
            ResultCode = ResponseResultCode.Success,
        };
    }
}
