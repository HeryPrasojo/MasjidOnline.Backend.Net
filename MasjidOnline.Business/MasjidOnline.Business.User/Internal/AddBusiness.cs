using System;
using System.Threading.Tasks;
using MasjidOnline.Business.Authorization.Interface;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Business.Model.User.Internal;
using MasjidOnline.Business.User.Interface.Internal;
using MasjidOnline.Data.Interface;
using MasjidOnline.Library.Exceptions;
using MasjidOnline.Service.Interface;

namespace MasjidOnline.Business.User.Internal;

public class AddBusiness(
    IAuthorizationBusiness _authorizationBusiness,
    IService _service) : IAddBusiness
{
    public async Task<Response> AddAsync(Model.Session.Session session, IData _data, AddRequest? addRequest)
    {
        await _authorizationBusiness.User.Internal.AuthorizeAddAync(session, _data);


        addRequest = _service.FieldValidator.ValidateRequired(addRequest);

        addRequest.Contact = _service.FieldValidator.ValidateRequiredTextDb255(addRequest.Contact);


        var userId = await _data.User.UserEmail.GetUserIdAsync(addRequest.Contact);

        if (userId == default) throw new InputMismatchException(nameof(addRequest.Contact));


        var user = await _data.User.User.GetForInternalAddAsync(userId);

        if (user == default) throw new DataMismatchException(nameof(addRequest.Contact));

        if (user.Type != Entity.User.UserType.External) throw new InputMismatchException(nameof(addRequest.Contact));

        if (user.Status != Entity.User.UserStatus.Active) throw new InputMismatchException(nameof(addRequest.Contact));


        var any = await _data.User.InternalUser.AnyNewAsync(userId);

        if (any) throw new InputMismatchException(nameof(addRequest.Contact));


        var internalUser = new Entity.User.InternalUser
        {
            AddUserId = session.UserId,
            DateTime = DateTime.UtcNow,
            Id = _data.IdGenerator.User.InternalId,
            Status = Entity.User.InternalUserStatus.New,
            UserId = userId,
        };

        await _data.User.InternalUser.AddAndSaveAsync(internalUser);


        // todo wait approver notification

        return new()
        {
            ResultCode = ResponseResultCode.Success
        };
    }
}
