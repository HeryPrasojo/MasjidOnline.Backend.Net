using System.Threading.Tasks;
using MasjidOnline.Business.Infaq.Interface.Model.Void;
using MasjidOnline.Business.Infaq.Interface.Void;
using MasjidOnline.Business.Infaq.Void.Mapper;
using MasjidOnline.Business.Interface.Model.Responses;
using MasjidOnline.Data.Interface.Datas;
using MasjidOnline.Library.Exceptions;
using MasjidOnline.Service.FieldValidator.Interface;

namespace MasjidOnline.Business.Infaq.Void;

public class GetOneBusiness(
    IFieldValidatorService _fieldValidatorService) : IGetOneBusiness
{
    public async Task<GetOneResponse> GetAsync(
        IInfaqDatabase _infaqDatabase,
        GetOneRequest? getOneRequest)
    {
        _fieldValidatorService.ValidateRequired(getOneRequest);
        _fieldValidatorService.ValidateRequiredPlus(getOneRequest!.Id);


        var infaq = await _infaqDatabase.Void.GetOneAsync(getOneRequest.Id!.Value);

        if (infaq == default) throw new InputMismatchException($"{nameof(getOneRequest.Id)}: {getOneRequest.Id}");

        return new()
        {
            ResultCode = ResponseResultCode.Success,
            DateTime = infaq.DateTime,
            Status = infaq.Status.ToModel(),
            UpdateDateTime = infaq.UpdateDateTime,
            UpdateUserId = infaq.UpdateUserId,
            UserId = infaq.UserId,
        };
    }
}
