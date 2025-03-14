using System.Threading.Tasks;
using MasjidOnline.Business.Interface.Model.Responses;
using MasjidOnline.Business.User.Interface.Internal;
using MasjidOnline.Business.User.Interface.Model.Internal;
using MasjidOnline.Data.Interface.Datas;
using MasjidOnline.Library.Exceptions;
using MasjidOnline.Service.FieldValidator.Interface;

namespace MasjidOnline.Business.User.Internal;

public class GetOneNewBusiness(
    IFieldValidatorService _fieldValidatorService) : IGetOneNewBusiness
{
    public async Task<GetOneNewResponse> GetAsync(
        IUserData _userData,
        GetOneNewRequest getOneNewRequest)
    {
        _fieldValidatorService.ValidateRequired(getOneNewRequest);
        _fieldValidatorService.ValidateRequiredPlus(getOneNewRequest.Id);


        var @internal = await _userData.Internal.GetOneNewAsync(getOneNewRequest.Id);

        if (@internal == default) throw new InputMismatchException($"{nameof(getOneNewRequest.Id)}: {getOneNewRequest.Id}");

        return new()
        {
            ResultCode = ResponseResultCode.Success,
            DateTime = @internal.DateTime,
            EmailAddress = @internal.EmailAddress,
            UserId = @internal.UserId,
        };
    }
}
