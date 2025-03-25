using System.Threading.Tasks;
using MasjidOnline.Business.Interface.Model.Responses;
using MasjidOnline.Business.User.Interface.Internal;
using MasjidOnline.Business.User.Interface.Model.Internal;
using MasjidOnline.Data.Interface.Databases;
using MasjidOnline.Library.Exceptions;
using MasjidOnline.Service.FieldValidator.Interface;

namespace MasjidOnline.Business.User.Internal;

public class GetOneNewBusiness(
    IFieldValidatorService _fieldValidatorService) : IGetOneNewBusiness
{
    public async Task<GetOneNewResponse> GetAsync(
        IData _data,
        GetOneNewRequest? getOneNewRequest)
    {
        _fieldValidatorService.ValidateRequired(getOneNewRequest);
        _fieldValidatorService.ValidateRequiredPlus(getOneNewRequest!.Id);


        var @internal = await _data.Internal.GetOneNewAsync(getOneNewRequest.Id!.Value);

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
