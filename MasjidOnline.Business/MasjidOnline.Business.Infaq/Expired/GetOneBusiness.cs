using System.Threading.Tasks;
using MasjidOnline.Business.Infaq.Interface.Expired;
using MasjidOnline.Business.Infaq.Interface.Model.Expired;
using MasjidOnline.Business.Interface.Model.Responses;
using MasjidOnline.Data.Interface.Datas;
using MasjidOnline.Library.Exceptions;
using MasjidOnline.Service.FieldValidator.Interface;

namespace MasjidOnline.Business.Infaq.Expired;

public class GetOneBusiness(
    IFieldValidatorService _fieldValidatorService) : IGetOneBusiness
{
    public async Task<GetOneResponse> GetAsync(
        IInfaqsData _infaqsData,
        GetOneRequest getOneRequest)
    {
        _fieldValidatorService.ValidateRequired(getOneRequest);
        _fieldValidatorService.ValidateRequiredPlus(getOneRequest.InfaqId);


        var infaq = await _infaqsData.Expired.GetOneAsync(getOneRequest.InfaqId);

        if (infaq == default) throw new InputMismatchException($"{nameof(getOneRequest.InfaqId)}: {getOneRequest.InfaqId}");

        return new()
        {
            ResultCode = ResponseResultCode.Success,
            DateTime = infaq.DateTime,
            InfaqId = infaq.InfaqId,
            IsApproved = infaq.IsApproved,
            UpdateDateTime = infaq.UpdateDateTime,
            UpdateUserId = infaq.UpdateUserId,
            UserId = infaq.UserId,
        };
    }
}
