using System.Linq;
using System.Threading.Tasks;
using MasjidOnline.Business.Infaq.Interface.Expired;
using MasjidOnline.Business.Infaq.Interface.Model.Expired;
using MasjidOnline.Business.Interface.Model.Responses;
using MasjidOnline.Data.Interface.Datas;
using MasjidOnline.Data.Interface.ViewModel.Infaq.Expired;
using MasjidOnline.Data.Interface.ViewModel.Repository;
using MasjidOnline.Service.FieldValidator.Interface;

namespace MasjidOnline.Business.Infaq.Expired;

public class GetManyNewBusiness(
    IFieldValidatorService _fieldValidatorService) : IGetManyNewBusiness
{
    public async Task<GetManyResponse<GetManyNewResponseRecord>> GetAsync(
        IInfaqData _infaqData,
        GetManyNewRequest getManyUnprovedRequest)
    {
        _fieldValidatorService.ValidateRequired(getManyUnprovedRequest);
        _fieldValidatorService.ValidateRequiredPlus(getManyUnprovedRequest.Page);


        var take = 10;

        var getManyResult = await _infaqData.Expired.GetManyNewAsync(
            getManyOrderBy: ManyOrderBy.DateTime,
            orderByDirection: OrderByDirection.Descending,
            skip: (getManyUnprovedRequest.Page - 1) * take,
            take: take);

        return new()
        {
            ResultCode = ResponseResultCode.Success,
            Records = getManyResult.Records.Select(m => new GetManyNewResponseRecord
            {
                DateTime = m.DateTime,
                InfaqId = m.InfaqId,
                UserId = m.UserId,
            }),
            Total = getManyResult.Total,
        };
    }
}
