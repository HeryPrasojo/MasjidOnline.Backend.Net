using System;
using System.Threading.Tasks;
using MasjidOnline.Business.Accountancy.Interface.Expenditure;
using MasjidOnline.Business.Authorization.Interface;
using MasjidOnline.Business.Model.Accountancy.Expenditure;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Data.Interface;
using MasjidOnline.Library.Exceptions;
using MasjidOnline.Service.Interface;

namespace MasjidOnline.Business.Accountancy.Expenditure;

public class RejectBusiness(IAuthorizationBusiness _authorizationBusiness, IService _service) : IRejectBusiness
{
    public async Task<Response> RejectAsync(Model.Session.Session session, IData _data, RejectRequest? rejectRequest)
    {
        await _authorizationBusiness.Accountancy.Expenditure.AuthorizeApproveAync(session, _data);

        rejectRequest = _service.FieldValidator.ValidateRequired(rejectRequest);
        rejectRequest.Id = _service.FieldValidator.ValidateRequiredPlus(rejectRequest.Id);
        rejectRequest.Description = _service.FieldValidator.ValidateRequiredTextDb255(rejectRequest.Description);


        var status = await _data.Accountancy.Expenditure.GetStatusAsync(rejectRequest.Id.Value);

        if (status != Entity.Accountancy.ExpenditureStatus.New) throw new InputMismatchException($"{nameof(status)}: {status}");


        await _data.Accountancy.Expenditure.SetStatusAndSaveAsync(
            rejectRequest.Id.Value,
            Entity.Accountancy.ExpenditureStatus.Reject,
            rejectRequest.Description,
            DateTime.UtcNow,
            session.UserId);

        // todo wait requester notification

        return new()
        {
            ResultCode = ResponseResultCode.Success,
        };
    }
}
