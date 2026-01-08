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

public class CancelBusiness(IAuthorizationBusiness _authorizationBusiness, IService _service) : ICancelBusiness
{
    public async Task<Response> CancelAsync(Model.Session.Session session, IData _data, CancelRequest? cancelRequest)
    {
        await _authorizationBusiness.Accountancy.Expenditure.AuthorizeAddAync(session, _data);

        cancelRequest = _service.FieldValidator.ValidateRequired(cancelRequest);
        cancelRequest.Id = _service.FieldValidator.ValidateRequiredPlus(cancelRequest.Id);
        cancelRequest.Description = _service.FieldValidator.ValidateRequiredTextDb255(cancelRequest.Description);


        var status = await _data.Accountancy.Expenditure.GetStatusAsync(cancelRequest.Id.Value);

        if (status != Entity.Accountancy.ExpenditureStatus.New) throw new InputMismatchException($"{nameof(status)}: {status}");


        await _data.Accountancy.Expenditure.SetStatusAndSaveAsync(
            cancelRequest.Id.Value,
            Entity.Accountancy.ExpenditureStatus.Cancel,
            cancelRequest.Description,
            DateTime.UtcNow,
            session.UserId);

        return new()
        {
            ResultCode = ResponseResultCode.Success,
        };
    }
}
