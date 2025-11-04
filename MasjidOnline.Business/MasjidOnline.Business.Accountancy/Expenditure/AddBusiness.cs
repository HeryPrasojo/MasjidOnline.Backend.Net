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
    IService _service) : IAddBusiness
{
    public async Task<Response> AddAsync(Session.Interface.Model.Session session, IData _data, AddRequest? addRequest)
    {
        await _authorizationBusiness.Accountancy.Expenditure.AuthorizeAddAync(session, _data);


        addRequest = _service.FieldValidator.ValidateRequired(addRequest);

        addRequest.Amount = _service.FieldValidator.ValidateRequiredPlus(addRequest.Amount);
        addRequest.Description = _service.FieldValidator.ValidateRequiredTextDb255(addRequest.Description);


        var expenditure = new Entity.Accountancy.Expenditure
        {
            Amount = addRequest.Amount.Value,
            DateTime = DateTime.UtcNow,
            Description = addRequest.Description,
            Id = _data.IdGenerator.Accountancy.ExpenditureId,
            Status = Entity.Accountancy.ExpenditureStatus.New,
            UserId = session.UserId,
        };

        await _data.Accountancy.Expenditure.AddAndSaveAsync(expenditure);

        // todo wait notification approver

        return new()
        {
            ResultCode = ResponseResultCode.Success
        };
    }
}
