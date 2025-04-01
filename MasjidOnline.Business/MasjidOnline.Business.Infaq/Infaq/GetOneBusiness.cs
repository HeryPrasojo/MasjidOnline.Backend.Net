using System.Threading.Tasks;
using MasjidOnline.Business.Infaq.Infaq.Mapper;
using MasjidOnline.Business.Infaq.Interface.Infaq;
using MasjidOnline.Business.Infaq.Interface.Model.Infaq;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Data.Interface;
using MasjidOnline.Library.Exceptions;
using MasjidOnline.Service.Interface;

namespace MasjidOnline.Business.Infaq.Infaq;

public class GetOneBusiness(IService _service) : IGetOneBusiness
{
    public async Task<GetOneResponse> GetAsync(IData _data, GetOneRequest? getOneRequest)
    {
        _service.FieldValidator.ValidateRequired(getOneRequest);
        _service.FieldValidator.ValidateRequiredPlus(getOneRequest!.Id);


        var infaq = await _data.Infaq.Infaq.GetOneAsync(getOneRequest.Id!.Value);

        if (infaq == default) throw new InputMismatchException($"{nameof(getOneRequest.Id)}: {getOneRequest.Id}");

        return new()
        {
            ResultCode = ResponseResultCode.Success,
            Amount = infaq.Amount,
            DateTime = infaq.DateTime,
            MunfiqName = infaq.MunfiqName,
            PaymentStatus = infaq.PaymentStatus.ToModel(),
            PaymentType = infaq.PaymentType.ToModel(),
        };
    }
}
