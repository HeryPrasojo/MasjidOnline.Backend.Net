using System;
using System.Threading.Tasks;
using MasjidOnline.Business.Accountancy.Interface.Expenditure;
using MasjidOnline.Business.Accountancy.Interface.Model.Expenditure;
using MasjidOnline.Business.Authorization.Interface;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Data.Interface;
using MasjidOnline.Library.Exceptions;
using MasjidOnline.Service.Interface;

namespace MasjidOnline.Business.Accountancy.Expenditure;

public class ApproveBusiness(
    IAuthorizationBusiness _authorizationBusiness,
    IService _service) : IApproveBusiness
{
    public async Task<Response> ApproveAsync(Session.Interface.Model.Session session, IData _data, ApproveRequest? approveRequest)
    {
        await _authorizationBusiness.Accountancy.Expenditure.AuthorizeApproveAync(session, _data);

        approveRequest = _service.FieldValidator.ValidateRequired(approveRequest);
        approveRequest.Id = _service.FieldValidator.ValidateRequiredPlus(approveRequest.Id);


        var @internal = await _data.Accountancy.Expenditure.GetForApproveAsync(approveRequest.Id.Value);

        if (@internal == default) throw new InputMismatchException($"{nameof(approveRequest.Id)}: {approveRequest.Id}");

        if (@internal.Status != Entity.Accountancy.ExpenditureStatus.New) throw new InputMismatchException($"{nameof(@internal.Status)}: {@internal.Status}");


        await _data.Accountancy.Expenditure.SetStatusAndSaveAsync(
            approveRequest.Id.Value,
            Entity.Accountancy.ExpenditureStatus.Approve,
            default,
            DateTime.UtcNow,
            session.UserId);

        return new()
        {
            ResultCode = ResponseResultCode.Success,
        };
    }
}
