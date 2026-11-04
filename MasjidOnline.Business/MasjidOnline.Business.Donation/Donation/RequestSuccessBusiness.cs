using System;
using System.Threading.Tasks;
using MasjidOnline.Business.Authorization.Interface;
using MasjidOnline.Business.Donation.Interface.Donation;
using MasjidOnline.Business.Model.Donation.Donation;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Data.Interface;
using MasjidOnline.Service.Interface;

namespace MasjidOnline.Business.Donation.Donation;

public class RequestSuccessBusiness(IAuthorizationBusiness _authorizationBusiness, IService _service) : IRequestSuccessBusiness
{
    public async Task<Response> RequestAsync(Model.Session.Session session, IData _data, RequestSuccessRequest requestSuccessRequest)
    {
        await _authorizationBusiness.Donation.Donation.AuthorizeRequestFailAync(session, _data);


        requestSuccessRequest = _service.FieldValidator.ValidateRequired(requestSuccessRequest);

        requestSuccessRequest.Id = _service.FieldValidator.ValidateRequiredPlus(requestSuccessRequest.Id);


        var donationStatus = await _data.Donation.Donation.GetStatusAsync(requestSuccessRequest.Id.Value);

        if (donationStatus != Entity.Donation.DonationStatus.New) return new()
        {
            ResultCode = ResponseResultCode.InputMismatch,
            ResultMessage = $"Status: {donationStatus}",
        };


        await _data.Transaction.BeginAsync(_data.Approval, _data.Donation, _data.Payment);

        _data.Donation.Donation.SetStatus(requestSuccessRequest.Id.Value, Entity.Donation.DonationStatus.SuccessRequest);

        _data.Payment.Payment.SetStatus(requestSuccessRequest.Id.Value, Entity.Payment.PaymentStatus.SuccessRequest);



        var approval = new Entity.Approval.Approval
        {
            DateTime = DateTime.UtcNow,
            Id = _data.IdGenerator.Approval.ApprovalId,
            Type = Entity.Approval.ApprovalType.Donation,
            TypeId = requestSuccessRequest.Id.Value,
            Status = Entity.Approval.ApprovalStatus.Request,
            Step = 0,
            UserId = session.UserId,
        };

        await _data.Approval.Approval.AddAsync(approval);

        await _data.Transaction.CommitAsync();

        return new()
        {
            ResultCode = ResponseResultCode.Success,
        };
    }
}
