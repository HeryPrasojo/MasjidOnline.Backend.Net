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
    public async Task<Response> RequestAsync(Model.Session.Session session, IData _data, RequestFailRequest failRequest)
    {
        failRequest = _service.FieldValidator.ValidateRequired(failRequest);

        failRequest.Id = _service.FieldValidator.ValidateRequiredPlus(failRequest.Id);
        failRequest.Description = _service.FieldValidator.ValidateRequired(failRequest.Description);


        await _authorizationBusiness.Donation.Donation.AuthorizeRequestFailAync(session, _data);


        var donationStatus = await _data.Donation.Donation.GetStatusAsync(failRequest.Id.Value);

        if (donationStatus != Entity.Donation.DonationStatus.New) return new()
        {
            ResultCode = ResponseResultCode.InputMismatch,
            ResultMessage = $"Status: {donationStatus}",
        };


        await _data.Transaction.BeginAsync(_data.Approval, _data.Donation, _data.Payment);

        _data.Donation.Donation.SetStatus(failRequest.Id.Value, Entity.Donation.DonationStatus.FailRequest);

        _data.Payment.Payment.SetStatus(failRequest.Id.Value, Entity.Payment.PaymentStatus.FailRequest);



        var approval = new Entity.Approval.Approval
        {
            DateTime = DateTime.UtcNow,
            Description = failRequest.Description,
            Id = _data.IdGenerator.Approval.ApprovalId,
            Type = Entity.Approval.ApprovalType.Donation,
            TypeId = failRequest.Id.Value,
            Status = Entity.Approval.ApprovalStatus.Request,
            Step = 0,
            UserId = session.UserId,
        };

        await _data.Approval.Approval.AddAsync(approval);


        //var approvalStep=new Entity.Approval.ApprovalStep
        //{ 
        //    ApprovalId= approval.Id,
        //    Id =_data.IdGenerator.Approval.ApprovalStepId,
        //};

        //await _data.Approval.ApprovalStep.AddAsync(approvalStep);

        await _data.Transaction.CommitAsync();

        return new()
        {
            ResultCode = ResponseResultCode.Success,
        };
    }
}
