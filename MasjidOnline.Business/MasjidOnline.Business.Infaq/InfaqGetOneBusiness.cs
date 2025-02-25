using System.Threading.Tasks;
using MasjidOnline.Business.Infaq.Interface;
using MasjidOnline.Business.Infaq.Interface.Model.Infaq;
using MasjidOnline.Business.Infaq.Interface.Model.Payment;
using MasjidOnline.Business.Interface.Model.Responses;
using MasjidOnline.Data.Interface.Datas;
using MasjidOnline.Library.Exceptions;
using MasjidOnline.Service.FieldValidator.Interface;

namespace MasjidOnline.Business.Infaq;

public class InfaqGetOneBusiness(
    IFieldValidatorService _fieldValidatorService) : IInfaqGetOneBusiness
{
    public async Task<GetOneResponse> GetAsync(
        IInfaqsData _infaqsData,
        GetOneRequest getOneRequest)
    {
        _fieldValidatorService.ValidateRequired(getOneRequest);
        _fieldValidatorService.ValidateRequiredPlus(getOneRequest.Id);


        var infaq = await _infaqsData.Infaq.GetOneByIdAsync(getOneRequest.Id);

        if (infaq == default) throw new InputMismatchException($"{nameof(getOneRequest.Id)}: {getOneRequest.Id}");

        return new()
        {
            ResultCode = ResponseResultCode.Success,
            Amount = infaq.Amount,
            DateTime = infaq.DateTime,
            MunfiqName = infaq.MunfiqName,
            PaymentStatus = (PaymentStatus)infaq.PaymentStatus,
            PaymentType = (PaymentType)infaq.PaymentType,
        };
    }
}
