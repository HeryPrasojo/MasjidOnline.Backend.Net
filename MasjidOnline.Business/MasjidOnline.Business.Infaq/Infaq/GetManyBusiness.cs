using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasjidOnline.Business.Infaq.Infaq.Mapper;
using MasjidOnline.Business.Infaq.Interface.Infaq;
using MasjidOnline.Business.Infaq.Interface.Model.Infaq;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Data.Interface;
using MasjidOnline.Data.Interface.ViewModel.Infaq.Infaq;
using MasjidOnline.Data.Interface.ViewModel.Repository;
using MasjidOnline.Entity.Payment;
using MasjidOnline.Service.Interface;

namespace MasjidOnline.Business.Infaq.Infaq;

public class GetManyBusiness(IService _service) : IGetManyBusiness
{
    public async Task<GetManyResponse<GetManyResponseRecord>> GetAsync(IData _data, GetManyRequest? getManyRequest)
    {
        getManyRequest = _service.FieldValidator.ValidateRequired(getManyRequest);
        getManyRequest.Page = _service.FieldValidator.ValidateRequiredPlus(getManyRequest.Page);


        IEnumerable<PaymentType>? paymentTypes = default;

        if (getManyRequest.PaymentTypes != default)
            paymentTypes = getManyRequest.PaymentTypes.Select(m => m.ToEntity());


        IEnumerable<PaymentStatus>? paymentStatuses = default;

        if (getManyRequest.PaymentStatuses != default)
            paymentStatuses = getManyRequest.PaymentStatuses.Select(m => m.ToEntity());


        var take = 10;

        var getManyResult = await _data.Infaq.Infaq.GetManyAsync(
            paymentTypes: paymentTypes,
            paymentStatuses: paymentStatuses,
            getManyOrderBy: ManyOrderBy.Id,
            orderByDirection: OrderByDirection.Descending,
            skip: (getManyRequest.Page.Value - 1) * take,
            take: take);

        return new()
        {
            PageCount = ((getManyResult.RecordCount - 1) / take) + 1,
            ResultCode = ResponseResultCode.Success,
            Records = getManyResult.Records.Select(e => new GetManyResponseRecord
            {
                Amount = _service.Localization.FormatDecimal(e.Amount),
                DateTime = _service.Localization.FormatDateTime(e.DateTime),
                Id = _service.Localization.FormatInt(e.Id),
                MunfiqName = e.MunfiqName,
                PaymentStatus = _service.Localization.Strings.PaymentStatus[e.PaymentStatus.ToLocale()],
                PaymentType = e.PaymentType.ToModel(),
            }),
            RecordCount = getManyResult.RecordCount,
        };
    }
}
