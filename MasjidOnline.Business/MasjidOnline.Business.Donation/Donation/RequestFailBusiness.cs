using System;
using System.Threading.Tasks;
using MasjidOnline.Business.Authorization.Interface;
using MasjidOnline.Business.Donation.Interface.Donation;
using MasjidOnline.Business.Model.Donation.Donation;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Data.Interface;
using MasjidOnline.Service.Interface;

namespace MasjidOnline.Business.Donation.Donation;

public class RequestFailBusiness(IAuthorizationBusiness _authorizationBusiness, IService _service) : IRequestFailBusiness
{
    public async Task<Response> RequestAsync(Model.Session.Session session, IData _data, RequestFailRequest requestFailRequest)
    {
        await _authorizationBusiness.Donation.Donation.AuthorizeRequestFailAync(session, _data);


        requestFailRequest = _service.FieldValidator.ValidateRequired(requestFailRequest);

        requestFailRequest.Id = _service.FieldValidator.ValidateRequiredPlus(requestFailRequest.Id);
        requestFailRequest.Description = _service.FieldValidator.ValidateRequired(requestFailRequest.Description);


        var donationStatus = await _data.Donation.Donation.GetStatusAsync(requestFailRequest.Id.Value);

        if (donationStatus != Entity.Donation.DonationStatus.New) return new()
        {
            ResultCode = ResponseResultCode.InputMismatch,
            ResultMessage = $"Status: {donationStatus}",
        };


        await _data.Transaction.BeginAsync(_data.Approval, _data.Donation, _data.Payment);

        _data.Donation.Donation.SetStatus(requestFailRequest.Id.Value, Entity.Donation.DonationStatus.FailRequest);

        _data.Payment.Payment.SetStatus(requestFailRequest.Id.Value, Entity.Payment.PaymentStatus.FailRequest);



        var approval = new Entity.Approval.Approval
        {
            DateTime = DateTime.UtcNow,
            Description = requestFailRequest.Description,
            Id = _data.IdGenerator.Approval.ApprovalId,
            Type = Entity.Approval.ApprovalType.Donation,
            TypeId = requestFailRequest.Id.Value,
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
