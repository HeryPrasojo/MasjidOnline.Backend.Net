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

public class RejectFailBusiness(IAuthorizationBusiness _authorizationBusiness, IService _service) : IRejectFailBusiness
{
    public async Task<Response> RejectAsync(Model.Session.Session session, IData _data, RejectFailRequest rejectFailRequest)
    {
        await _authorizationBusiness.Donation.Donation.AuthorizeRequestFailAync(session, _data);


        rejectFailRequest = _service.FieldValidator.ValidateRequired(rejectFailRequest);

        rejectFailRequest.Id = _service.FieldValidator.ValidateRequiredPlus(rejectFailRequest.Id);
        rejectFailRequest.Description = _service.FieldValidator.ValidateRequired(rejectFailRequest.Description);


        var donationStatus = await _data.Donation.Donation.GetStatusAsync(rejectFailRequest.Id.Value);

        if (donationStatus != Entity.Donation.DonationStatus.FailRequest) return new()
        {
            ResultCode = ResponseResultCode.InputMismatch,
            ResultMessage = $"Status: {donationStatus}",
        };


        var approvalId = await _data.Approval.Approval.GetIdAsync(ApprovalType.Donation, rejectFailRequest.Id.Value);

        if (approvalId == default) return new()
        {
            ResultCode = ResponseResultCode.DataMismatch,
            ResultMessage = $"Status: {donationStatus}",
        };


        await _data.Transaction.BeginAsync(_data.Approval, _data.Donation, _data.Payment);

        _data.Donation.Donation.SetStatus(rejectFailRequest.Id.Value, Entity.Donation.DonationStatus.New);

        _data.Payment.Payment.SetStatus(rejectFailRequest.Id.Value, Entity.Payment.PaymentStatus.New);

        await _data.Approval.Approval.SetStatusAsync(approvalId, 1, ApprovalStatus.Reject);


        var approvalStep = new ApprovalStep
        {
            ApprovalId = approvalId,
            DateTime = DateTime.UtcNow,
            Description = rejectFailRequest.Description,
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
