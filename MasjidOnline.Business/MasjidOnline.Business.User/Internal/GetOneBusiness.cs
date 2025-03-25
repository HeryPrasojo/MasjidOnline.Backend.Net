using System.Threading.Tasks;
using MasjidOnline.Business.Interface.Model.Responses;
using MasjidOnline.Business.User.Interface.Internal;
using MasjidOnline.Business.User.Interface.Model.Internal;
using MasjidOnline.Business.User.Internal.Mapper;
using MasjidOnline.Data.Interface.Databases;
using MasjidOnline.Library.Exceptions;
using MasjidOnline.Service.FieldValidator.Interface;

namespace MasjidOnline.Business.User.Internal;

public class GetOneBusiness(IFieldValidatorService _fieldValidatorService) : IGetOneBusiness
{
    public async Task<GetOneResponse> GetAsync(
        IUserDatabase _userDatabase,
        GetOneRequest? getOneRequest)
    {
        _fieldValidatorService.ValidateRequired(getOneRequest);
        _fieldValidatorService.ValidateRequiredPlus(getOneRequest!.Id);


        var @internal = await _userDatabase.Internal.GetOneAsync(getOneRequest.Id!.Value);

        if (@internal == default) throw new InputMismatchException($"{nameof(getOneRequest.Id)}: {getOneRequest.Id}");

        return new()
        {
            ResultCode = ResponseResultCode.Success,
            DateTime = @internal.DateTime,
            Status = @internal.Status.ToModel(),
            UpdateDateTime = @internal.UpdateDateTime,
            UpdateUserId = @internal.UpdateUserId,
            UserId = @internal.UserId,
        };
    }
}
