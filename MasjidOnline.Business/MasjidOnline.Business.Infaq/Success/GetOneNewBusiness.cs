using System.Threading.Tasks;
using MasjidOnline.Business.Infaq.Interface.Model.Success;
using MasjidOnline.Business.Infaq.Interface.Success;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Data.Interface;
using MasjidOnline.Library.Exceptions;
using MasjidOnline.Service.Interface;

namespace MasjidOnline.Business.Infaq.Success;

public class GetOneNewBusiness(IService _service) : IGetOneNewBusiness
{
    public async Task<GetOneNewResponse> GetAsync(IData _data, GetOneNewRequest? getOneNewRequest)
    {
        getOneNewRequest = _service.FieldValidator.ValidateRequired(getOneNewRequest);
        _service.FieldValidator.ValidateRequiredPlus(getOneNewRequest.Id);


        var success = await _data.Infaq.Success.GetOneNewAsync(getOneNewRequest.Id!.Value);

        if (success == default) throw new InputMismatchException($"{nameof(getOneNewRequest.Id)}: {getOneNewRequest.Id}");

        return new()
        {
            ResultCode = ResponseResultCode.Success,
            DateTime = success.DateTime,
            InfaqId = success.InfaqId,
            UserId = success.UserId,
        };
    }
}
