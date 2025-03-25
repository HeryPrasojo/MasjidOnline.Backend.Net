using System.Threading.Tasks;
using MasjidOnline.Business.Infaq.Interface.Model.Success;
using MasjidOnline.Business.Infaq.Interface.Success;
using MasjidOnline.Business.Interface.Model.Responses;
using MasjidOnline.Data.Interface.Datas;
using MasjidOnline.Library.Exceptions;
using MasjidOnline.Service.FieldValidator.Interface;

namespace MasjidOnline.Business.Infaq.Success;

public class GetOneNewBusiness(
    IFieldValidatorService _fieldValidatorService) : IGetOneNewBusiness
{
    public async Task<GetOneNewResponse> GetAsync(
        IInfaqDatabase _infaqDatabase,
        GetOneNewRequest? getOneNewRequest)
    {
        _fieldValidatorService.ValidateRequired(getOneNewRequest);
        _fieldValidatorService.ValidateRequiredPlus(getOneNewRequest!.Id);


        var success = await _infaqDatabase.Success.GetOneNewAsync(getOneNewRequest.Id!.Value);

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
