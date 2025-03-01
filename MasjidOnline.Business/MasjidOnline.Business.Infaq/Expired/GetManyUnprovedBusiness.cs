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

public class GetManyUnprovedBusiness(
    IFieldValidatorService _fieldValidatorService) : IGetManyUnprovedBusiness
{
    public async Task<GetManyResponse<GetManyUnprovedResponseRecord>> GetAsync(
        IInfaqsData _infaqsData,
        GetManyUnprovedRequest getManyUnprovedRequest)
    {
        _fieldValidatorService.ValidateRequired(getManyUnprovedRequest);
        _fieldValidatorService.ValidateRequiredPlus(getManyUnprovedRequest.Page);


        var take = 10;

        var getManyResult = await _infaqsData.Expired.GetManyUnprovedAsync(
            getManyOrderBy: GetManyOrderBy.DateTime,
            orderByDirection: OrderByDirection.Descending,
            skip: (getManyUnprovedRequest.Page - 1) * take,
            take: take);

        return new()
        {
            ResultCode = ResponseResultCode.Success,
            Records = getManyResult.Records.Select(m => new GetManyUnprovedResponseRecord
            {
                DateTime = m.DateTime,
                InfaqId = m.InfaqId,
                UserId = m.UserId,
            }),
            Total = getManyResult.Total,
        };
    }
}
