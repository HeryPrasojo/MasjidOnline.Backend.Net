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

public class RejectSuccessBusiness(IAuthorizationBusiness _authorizationBusiness, IService _service) : IRejectSuccessBusiness
{
    public async Task<Response> RejectAsync(Model.Session.Session session, IData _data, RejectSuccessRequest rejectSuccessRequest)
    {
        await _authorizationBusiness.Donation.Donation.AuthorizeRequestFailAync(session, _data);

        rejectSuccessRequest = _service.FieldValidator.ValidateRequired(rejectSuccessRequest);

        rejectSuccessRequest.Id = _service.FieldValidator.ValidateRequiredPlus(rejectSuccessRequest.Id);
        rejectSuccessRequest.Description = _service.FieldValidator.ValidateRequired(rejectSuccessRequest.Description);

        var donationStatus = await _data.Donation.Donation.GetStatusAsync(rejectSuccessRequest.Id.Value);

        if (donationStatus != Entity.Donation.DonationStatus.SuccessRequest) return new()
        {
            ResultCode = ResponseResultCode.InputMismatch,
            ResultMessage = $"Status: {donationStatus}",
        };

        var approvalId = await _data.Approval.Approval.GetIdAsync(ApprovalType.Donation, rejectSuccessRequest.Id.Value);

        if (approvalId == default) return new()
        {
            ResultCode = ResponseResultCode.DataMismatch,
            ResultMessage = $"Status: {donationStatus}",
        };

        await _data.Transaction.BeginAsync(_data.Approval, _data.Donation, _data.Payment);

        _data.Donation.Donation.SetStatus(rejectSuccessRequest.Id.Value, Entity.Donation.DonationStatus.New);

        _data.Payment.Payment.SetStatus(rejectSuccessRequest.Id.Value, Entity.Payment.PaymentStatus.New);

        await _data.Approval.Approval.SetStatusAsync(approvalId, 1, ApprovalStatus.Reject);

        var approvalStep = new ApprovalStep
        {
            ApprovalId = approvalId,
            DateTime = DateTime.UtcNow,
            Description = rejectSuccessRequest.Description,
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
