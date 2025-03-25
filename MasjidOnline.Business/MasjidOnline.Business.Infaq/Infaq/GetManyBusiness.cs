using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasjidOnline.Business.Infaq.Infaq.Mapper;
using MasjidOnline.Business.Infaq.Interface.Infaq;
using MasjidOnline.Business.Infaq.Interface.Model.Infaq;
using MasjidOnline.Business.Interface.Model.Responses;
using MasjidOnline.Data.Interface.Datas;
using MasjidOnline.Data.Interface.ViewModel.Infaq.Infaq;
using MasjidOnline.Data.Interface.ViewModel.Repository;
using MasjidOnline.Service.FieldValidator.Interface;

namespace MasjidOnline.Business.Infaq.Infaq;

public class GetManyBusiness(
    IFieldValidatorService _fieldValidatorService) : IGetManyBusiness
{
    public async Task<GetManyResponse<GetManyResponseRecord>> GetAsync(
        IInfaqDatabase _infaqDatabase,
        GetManyRequest? getManyRequest)
    {
        _fieldValidatorService.ValidateRequired(getManyRequest);
        _fieldValidatorService.ValidateRequiredPlus(getManyRequest!.Page);


        IEnumerable<Entity.Infaq.PaymentType>? paymentTypes = default;

        if (getManyRequest.PaymentTypes != default)
            paymentTypes = getManyRequest.PaymentTypes.Select(m => m.ToEntity());


        IEnumerable<Entity.Infaq.PaymentStatus>? paymentStatuses = default;

        if (getManyRequest.PaymentStatuses != default)
            paymentStatuses = getManyRequest.PaymentStatuses.Select(m => m.ToEntity());


        var take = 10;

        var getManyResult = await _infaqDatabase.Infaq.GetManyAsync(
            paymentTypes: paymentTypes,
            paymentStatuses: paymentStatuses,
            getManyOrderBy: ManyOrderBy.Id,
            orderByDirection: OrderByDirection.Descending,
            skip: (getManyRequest.Page!.Value - 1) * take,
            take: take);

        return new()
        {
            ResultCode = ResponseResultCode.Success,
            Records = getManyResult.Records.Select(e => new GetManyResponseRecord
            {
                Amount = e.Amount,
                DateTime = e.DateTime,
                Id = e.Id,
                MunfiqName = e.MunfiqName,
                PaymentStatus = e.PaymentStatus.ToModel(),
                PaymentType = e.PaymentType.ToModel(),
            }),
            Total = getManyResult.Total,
        };
    }
}
