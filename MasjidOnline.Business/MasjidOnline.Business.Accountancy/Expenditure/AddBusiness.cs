using System;
using System.Threading.Tasks;
using MasjidOnline.Business.Accountancy.Interface.Expenditure;
using MasjidOnline.Business.Accountancy.Interface.Model.Expenditure;
using MasjidOnline.Business.Authorization.Interface;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Data.Interface;
using MasjidOnline.Service.Interface;

namespace MasjidOnline.Business.Accountancy.Expenditure;

public class AddBusiness(
    IAuthorizationBusiness _authorizationBusiness,
    IIdGenerator _idGenerator,
    IService _service) : IAddBusiness
{
    public async Task<Response> AddAsync(Session.Interface.Model.Session session, IData _data, AddRequest? addRequest)
    {
        await _authorizationBusiness.AuthorizePermissionAsync(session, _data, accountancyExpenditureAdd: true);


        addRequest = _service.FieldValidator.ValidateRequired(addRequest);

        addRequest.EmailAddress = _service.FieldValidator.ValidateRequiredEmailAddress(addRequest.EmailAddress);
        addRequest.Name = _service.FieldValidator.ValidateRequiredText255(addRequest.Name);


        var @internal = new Entity.Accountancy.Expenditure
        {
            DateTime = DateTime.UtcNow,
            Description = addRequest.EmailAddress,
            Id = _idGenerator.Accountancy.ExpenditureId,
            Status = Entity.Accountancy.ExpenditureStatus.New,
            UserId = session.UserId,
        };

        await _data.Accountancy.Expenditure.AddAndSaveAsync(@internal);

        // todo approver notification

        return new()
        {
            ResultCode = ResponseResultCode.Success
        };
    }
}
