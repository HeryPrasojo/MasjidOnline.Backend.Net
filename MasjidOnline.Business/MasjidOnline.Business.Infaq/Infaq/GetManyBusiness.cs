using System.Linq;
using System.Threading.Tasks;
using MasjidOnline.Business.Infaq.Interface.Infaq;
using MasjidOnline.Business.Model.Infaq.Infaq;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Data.Interface;
using MasjidOnline.Service.Interface;

namespace MasjidOnline.Business.Infaq.Infaq;

public class GetManyBusiness(IService _service) : IGetManyBusiness
{
    public async Task<Response<GetManyResponse<GetManyResponseRecord>>> GetAsync(
        Model.Session.Session session,
        IData _data,
        GetManyRequest? getManyRequest)
    {
        getManyRequest = _service.FieldValidator.ValidateRequired(getManyRequest);
        getManyRequest.Page = _service.FieldValidator.ValidateRequiredPlus(getManyRequest.Page);
        _service.FieldValidator.ValidateOptionalEnums(getManyRequest.PaymentTypes);
        _service.FieldValidator.ValidateOptionalEnums(getManyRequest.Statuses);


        var paymentTypes = getManyRequest.PaymentTypes?.Select(pt => Mapper.Mapper.Payment.PaymentType[pt]);
        var infaqStatuses = getManyRequest.Statuses?.Select(m => Mapper.Mapper.Infaq.InfaqStatus[m]);

        var take = 10;

        var getManyResult = await _data.Infaq.Infaq.GetManyAsync(
            paymentTypes: paymentTypes,
            paymentStatuses: infaqStatuses,
            skip: (getManyRequest.Page.Value - 1) * take,
            take: take);

        return new()
        {
            ResultCode = ResponseResultCode.Success,
            Data = new()
            {
                PageCount = ((getManyResult.RecordCount - 1) / take) + 1,
                RecordCount = _service.Localization[getManyResult.RecordCount, session.CultureInfo],
                Records = getManyResult.Records.Select(e => new GetManyResponseRecord
                {
                    Amount = _service.Localization[e.Amount, session.CultureInfo],
                    DateTime = _service.Localization[e.DateTime, session.CultureInfo, "yyyy MMM dd, HH:mm"],
                    Id = e.Id,
                    MunfiqName = e.MunfiqName,
                    Status = _service.Localization[Mapper.Mapper.Infaq.InfaqStatus[e.Status], session.CultureInfo],
                    PaymentType = _service.Localization[Mapper.Mapper.Payment.PaymentType[e.PaymentType], session.CultureInfo],
                }),
            }
        };
    }
}
