using System;
using System.Threading.Tasks;
using MasjidOnline.Business.AuthorizationBusiness.Interface;
using MasjidOnline.Business.Interface.Model.Responses;
using MasjidOnline.Business.Session.Interface;
using MasjidOnline.Business.User.Interface.Internal;
using MasjidOnline.Business.User.Interface.Model.Internal;
using MasjidOnline.Data.Interface.Datas;
using MasjidOnline.Data.Interface.IdGenerator;
using MasjidOnline.Library.Exceptions;
using MasjidOnline.Service.FieldValidator.Interface;

namespace MasjidOnline.Business.User.Internal;

public class AddBusiness(
    IAuthorizationBusiness _authorizationBusiness,
    IUserIdGenerator _userIdGenerator,
    IFieldValidatorService _fieldValidatorService) : IAddBusiness
{
    public async Task<Response> AddAsync(
        ISessionBusiness _sessionBusiness,
        IUserData _userData,
        AddRequest addRequest)
    {
        await _authorizationBusiness.AuthorizePermissionAsync(_sessionBusiness, _userData, userInternalAdd: true);


        _fieldValidatorService.ValidateRequired(addRequest);

        addRequest.EmailAddress = _fieldValidatorService.ValidateRequiredEmailAddress(addRequest.EmailAddress);
        addRequest.Name = _fieldValidatorService.ValidateRequiredText255(addRequest.Name);


        // undone check exixts

        var any = await _userData.UserEmailAddress.AnyAsync(addRequest.EmailAddress);

        if (any) throw new InputMismatchException($"{addRequest.EmailAddress} exists");


        var @internal = new Entity.User.Internal
        {
            DateTime = DateTime.UtcNow,
            EmailAddress = addRequest.EmailAddress,
            Id = _userIdGenerator.InternalId,
            Status = Entity.User.InternalStatus.New,
            UserId = _sessionBusiness.UserId,
        };

        await _userData.Internal.AddAndSaveAsync(@internal);

        return new()
        {
            ResultCode = ResponseResultCode.Success
        };
    }
}
