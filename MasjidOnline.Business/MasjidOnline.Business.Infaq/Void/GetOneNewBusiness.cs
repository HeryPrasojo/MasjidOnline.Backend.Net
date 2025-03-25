using System.Threading.Tasks;
using MasjidOnline.Business.Infaq.Interface.Model.Void;
using MasjidOnline.Business.Infaq.Interface.Void;
using MasjidOnline.Business.Interface.Model.Responses;
using MasjidOnline.Data.Interface.Datas;
using MasjidOnline.Library.Exceptions;
using MasjidOnline.Service.FieldValidator.Interface;

namespace MasjidOnline.Business.Infaq.Void;

public class GetOneNewBusiness(
    IFieldValidatorService _fieldValidatorService) : IGetOneNewBusiness
{
    public async Task<GetOneNewResponse> GetAsync(
        IInfaqDatabase _infaqDatabase,
        GetOneNewRequest? getOneNewRequest)
    {
        _fieldValidatorService.ValidateRequired(getOneNewRequest);
        _fieldValidatorService.ValidateRequiredPlus(getOneNewRequest!.Id);


        var @void = await _infaqDatabase.Void.GetOneNewAsync(getOneNewRequest.Id!.Value);

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
