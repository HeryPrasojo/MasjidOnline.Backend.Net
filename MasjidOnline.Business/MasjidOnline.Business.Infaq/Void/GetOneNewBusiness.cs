using System.Threading.Tasks;
using MasjidOnline.Business.Infaq.Interface.Model.Void;
using MasjidOnline.Business.Infaq.Interface.Void;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Data.Interface;
using MasjidOnline.Library.Exceptions;
using MasjidOnline.Service.Interface;

namespace MasjidOnline.Business.Infaq.Void;

public class GetOneNewBusiness(IService _service) : IGetOneNewBusiness
{
    public async Task<GetOneNewResponse> GetAsync(IData _data, GetOneNewRequest? getOneNewRequest)
    {
        _service.FieldValidator.ValidateRequired(getOneNewRequest);
        _service.FieldValidator.ValidateRequiredPlus(getOneNewRequest!.Id);


        var @void = await _data.Infaq.Void.GetOneNewAsync(getOneNewRequest.Id!.Value);

        if (@void == default) throw new InputMismatchException($"{nameof(getOneNewRequest.Id)}: {getOneNewRequest.Id}");

        return new()
        {
            ResultCode = ResponseResultCode.Success,
            DateTime = @void.DateTime,
            InfaqId = @void.InfaqId,
            UserId = @void.UserId,
        };
    }
}
