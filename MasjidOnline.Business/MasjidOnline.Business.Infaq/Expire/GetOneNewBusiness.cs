using System.Threading.Tasks;
using MasjidOnline.Business.Infaq.Interface.Expire;
using MasjidOnline.Business.Infaq.Interface.Model.Expire;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Data.Interface;
using MasjidOnline.Library.Exceptions;
using MasjidOnline.Service.FieldValidator.Interface;

namespace MasjidOnline.Business.Infaq.Expire;

public class GetOneNewBusiness(
    IFieldValidatorService _fieldValidatorService) : IGetOneNewBusiness
{
    public async Task<GetOneNewResponse> GetAsync(
        IData _data,
        GetOneNewRequest? getOneNewRequest)
    {
        _fieldValidatorService.ValidateRequired(getOneNewRequest);
        _fieldValidatorService.ValidateRequiredPlus(getOneNewRequest!.Id);


        var expire = await _data.Infaq.Expire.GetOneNewAsync(getOneNewRequest.Id!.Value);

        if (expire == default) throw new InputMismatchException($"{nameof(getOneNewRequest.Id)}: {getOneNewRequest.Id}");

        return new()
        {
            ResultCode = ResponseResultCode.Success,
            DateTime = expire.DateTime,
            InfaqId = expire.InfaqId,
            UserId = expire.UserId,
        };
    }
}
