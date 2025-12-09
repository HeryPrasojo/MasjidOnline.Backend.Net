using System;
using System.Threading.Tasks;
using MasjidOnline.Business.Authorization.Interface;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Business.User.Interface.Internal;
using MasjidOnline.Business.User.Interface.Model.Internal;
using MasjidOnline.Data.Interface;
using MasjidOnline.Library.Exceptions;
using MasjidOnline.Service.Interface;

namespace MasjidOnline.Business.User.Internal;

public class AddBusiness(
    IAuthorizationBusiness _authorizationBusiness,
    IService _service) : IAddBusiness
{
    public async Task<Response> AddAsync(Session.Interface.Model.Session session, IData _data, AddRequest? addRequest)
    {
        await _authorizationBusiness.User.Internal.AuthorizeAddAync(session, _data);


        addRequest = _service.FieldValidator.ValidateRequired(addRequest);

        addRequest.EmailAddress = _service.FieldValidator.ValidateRequiredEmailAddress(addRequest.EmailAddress);
        addRequest.Name = _service.FieldValidator.ValidateRequiredTextDb255(addRequest.Name);


        var any = await _data.User.InternalUser.AnyAsync(addRequest.EmailAddress, Entity.User.InternalUserStatus.New);

        if (any) throw new InputMismatchException($"New {addRequest.EmailAddress} exists");


        any = await _data.User.UserEmailAddress.AnyAsync(addRequest.EmailAddress);

        if (any) throw new InputMismatchException($"{addRequest.EmailAddress} exists");


        var internalUser = new Entity.User.InternalUser
        {
            DateTime = DateTime.UtcNow,
            EmailAddress = addRequest.EmailAddress,
            Id = _data.IdGenerator.User.InternalId,
            Status = Entity.User.InternalUserStatus.New,
            UserId = session.UserId,
        };

        await _data.User.InternalUser.AddAndSaveAsync(internalUser);

        // todo wait approver notification

        // todo wait undone person, from existing user

        return new()
        {
            ResultCode = ResponseResultCode.Success
        };
    }
}
