using System.Threading.Tasks;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Business.User.Interface.Internal;
using MasjidOnline.Business.User.Interface.Model.Internal;
using MasjidOnline.Data.Interface;
using MasjidOnline.Library.Exceptions;
using MasjidOnline.Service.Interface;

namespace MasjidOnline.Business.User.Internal;

public class GetOneNewBusiness(IService _service) : IGetOneNewBusiness
{
    public async Task<GetOneNewResponse> GetAsync(IData _data, GetOneNewRequest? getOneNewRequest)
    {
        getOneNewRequest = _service.FieldValidator.ValidateRequired(getOneNewRequest);
        _service.FieldValidator.ValidateRequiredPlus(getOneNewRequest.Id);


        var @internal = await _data.User.Internal.GetOneNewAsync(getOneNewRequest.Id!.Value);

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
