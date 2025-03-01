using System.Linq;
using System.Threading.Tasks;
using MasjidOnline.Business.Infaq.Interface.Expired;
using MasjidOnline.Business.Infaq.Interface.Model.Expired;
using MasjidOnline.Business.Interface.Model.Responses;
using MasjidOnline.Data.Interface.Datas;
using MasjidOnline.Data.Interface.Model.Infaqs.Expired;
using MasjidOnline.Data.Interface.Model.Repository;
using MasjidOnline.Service.FieldValidator.Interface;

namespace MasjidOnline.Business.Infaq.Expired;

public class ExpiredGetManyBusiness(
    IFieldValidatorService _fieldValidatorService) : IGetManyBusiness
{
    public async Task<GetManyResponse<GetManyResponseRecord>> GetAsync(
        IInfaqsData _infaqsData,
        GetManyRequest getManyRequest)
    {
        _fieldValidatorService.ValidateRequired(getManyRequest);
        _fieldValidatorService.ValidateRequiredPlus(getManyRequest.Page);


        var take = 10;

        var getManyResult = await _infaqsData.Expired.GetManyAsync(
            isApproved: getManyRequest.IsApproved,
            getManyOrderBy: GetManyOrderBy.DateTime,
            orderByDirection: OrderByDirection.Descending,
            skip: (getManyRequest.Page - 1) * take,
            take: take);

        return new()
        {
            ResultCode = ResponseResultCode.Success,
            Records = getManyResult.Records.Select(m => new GetManyResponseRecord
            {
                DateTime = m.DateTime,
                InfaqId = m.InfaqId,
                IsApproved = m.IsApproved,
                UpdateDateTime = m.UpdateDateTime,
                UpdateUserId = m.UpdateUserId,
                UserId = m.UserId,
            }),
            Total = getManyResult.Total,
        };
    }
}
