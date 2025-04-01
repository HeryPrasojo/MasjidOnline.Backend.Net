using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasjidOnline.Business.Infaq.Infaq.Mapper;
using MasjidOnline.Business.Infaq.Interface.Infaq;
using MasjidOnline.Business.Infaq.Interface.Model.Infaq;
using MasjidOnline.Business.Model.Options;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Data.Interface;
using MasjidOnline.Data.Interface.ViewModel.Infaq.Infaq;
using MasjidOnline.Data.Interface.ViewModel.Repository;
using MasjidOnline.Service.Interface;
using Microsoft.Extensions.Options;

namespace MasjidOnline.Business.Infaq.Infaq;

public class GetManyDueBusiness(IOptionsMonitor<BusinessOptions> _optionsMonitor, IService _service) : IGetManyDueBusiness
{
    public async Task<GetManyResponse<GetManyDueResponseRecord>> GetAsync(IData _data, GetManyDueRequest? getManyDueRequest)
    {
        _service.FieldValidator.ValidateRequired(getManyDueRequest);
        _service.FieldValidator.ValidateRequiredPlus(getManyDueRequest!.Page);


        IEnumerable<Entity.Infaq.PaymentType>? paymentTypes = default;

        if (getManyDueRequest.PaymentTypes != default)
            paymentTypes = getManyDueRequest.PaymentTypes.Select(m => m.ToEntity());


        var take = 10;

        var getManyResult = await _data.Infaq.Infaq.GetManyDueAsync(
            DateTime.UtcNow.AddDays(_optionsMonitor.CurrentValue.PaymentExpire),
            paymentTypes: paymentTypes,
            getManyOrderBy: ManyOrderBy.Id,
            orderByDirection: OrderByDirection.Descending,
            skip: (getManyDueRequest.Page!.Value - 1) * take,
            take: take);

        return new()
        {
            ResultCode = ResponseResultCode.Success,
            Records = getManyResult.Records.Select(e => new GetManyDueResponseRecord
            {
                Amount = e.Amount,
                DateTime = e.DateTime,
                Id = e.Id,
                MunfiqName = e.MunfiqName,
                PaymentType = e.PaymentType.ToModel(),
            }),
            Total = getManyResult.Total,
        };
    }
}
