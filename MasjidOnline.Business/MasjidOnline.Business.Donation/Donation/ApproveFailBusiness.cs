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

public class ApproveFailBusiness(IAuthorizationBusiness _authorizationBusiness, IService _service) : IApproveFailBusiness
{
    public async Task<Response> ApproveAsync(Model.Session.Session session, IData _data, ApproveFailRequest approveFailRequest)
    {
        await _authorizationBusiness.Donation.Donation.AuthorizeRequestFailAync(session, _data);


        approveFailRequest = _service.FieldValidator.ValidateRequired(approveFailRequest);

        approveFailRequest.Id = _service.FieldValidator.ValidateRequiredPlus(approveFailRequest.Id);


        var donationStatus = await _data.Donation.Donation.GetStatusAsync(approveFailRequest.Id.Value);

        if (donationStatus != Entity.Donation.DonationStatus.FailRequest) return new()
        {
            ResultCode = ResponseResultCode.InputMismatch,
            ResultMessage = $"Status: {donationStatus}",
        };


        var approvalId = await _data.Approval.Approval.GetIdAsync(ApprovalType.Donation, approveFailRequest.Id.Value);

        if (approvalId == default) return new()
        {
            ResultCode = ResponseResultCode.DataMismatch,
            ResultMessage = $"Status: {donationStatus}",
        };


        await _data.Transaction.BeginAsync(_data.Approval, _data.Donation, _data.Payment);

        _data.Donation.Donation.SetStatus(approveFailRequest.Id.Value, Entity.Donation.DonationStatus.Fail);

        _data.Payment.Payment.SetStatus(approveFailRequest.Id.Value, Entity.Payment.PaymentStatus.Fail);

        await _data.Approval.Approval.SetStatusAsync(approvalId, 1, ApprovalStatus.Approve);


        var approvalStep = new ApprovalStep
        {
            ApprovalId = approvalId,
            DateTime = DateTime.UtcNow,
            Id = _data.IdGenerator.Approval.ApprovalStepId,
            Status = ApprovalStatus.Reject,
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
