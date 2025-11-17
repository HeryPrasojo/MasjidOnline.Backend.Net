using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasjidOnline.Business.Infaq.Infaq.Mapper;
using MasjidOnline.Business.Infaq.Interface.Infaq;
using MasjidOnline.Business.Infaq.Interface.Model.Infaq;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Data.Interface;
using MasjidOnline.Entity.Infaq;
using MasjidOnline.Entity.Payment;
using MasjidOnline.Service.Interface;

namespace MasjidOnline.Business.Infaq.Infaq;

public class GetManyBusiness(IService _service) : IGetManyBusiness
{
    public async Task<Response<GetManyResponse<GetManyResponseRecord>>> GetAsync(
        Session.Interface.Model.Session session,
        IData _data,
        GetManyRequest? getManyRequest)
    {
        getManyRequest = _service.FieldValidator.ValidateRequired(getManyRequest);
        getManyRequest.Page = _service.FieldValidator.ValidateRequiredPlus(getManyRequest.Page);


        IEnumerable<PaymentType>? paymentTypes = default;

        if (getManyRequest.PaymentTypes != default)
            paymentTypes = getManyRequest.PaymentTypes.Select(m => m.ToEntity());


        IEnumerable<InfaqStatus>? infaqStatuses = default;

        if (getManyRequest.PaymentStatuses != default)
            infaqStatuses = getManyRequest.PaymentStatuses.Select(m => m.ToEntity());


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
                RecordCount = getManyResult.RecordCount,
                Records = getManyResult.Records.Select(e => new GetManyResponseRecord
                {
                    Amount = e.Amount,
                    DateTime = e.DateTime,
                    Id = e.Id,
                    MunfiqName = e.MunfiqName,
                    Status = e.Status,
                    PaymentType = e.PaymentType,
                }),
            }
        };
    }
}
