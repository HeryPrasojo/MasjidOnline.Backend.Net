using System.Linq;
using System.Threading.Tasks;
using MasjidOnline.Business.Infaq.Interface.Model.Success;
using MasjidOnline.Business.Infaq.Interface.Success;
using MasjidOnline.Business.Interface.Model.Responses;
using MasjidOnline.Data.Interface.Datas;
using MasjidOnline.Data.Interface.ViewModel.Infaq.Success;
using MasjidOnline.Data.Interface.ViewModel.Repository;
using MasjidOnline.Service.FieldValidator.Interface;

namespace MasjidOnline.Business.Infaq.Success;

public class GetManyNewBusiness(
    IFieldValidatorService _fieldValidatorService) : IGetManyNewBusiness
{
    public async Task<GetManyResponse<GetManyNewResponseRecord>> GetAsync(
        IInfaqData _infaqData,
        GetManyNewRequest getManyNewRequest)
    {
        _fieldValidatorService.ValidateRequired(getManyNewRequest);
        _fieldValidatorService.ValidateRequiredPlus(getManyNewRequest.Page);


        var take = 10;

        var getManyResult = await _infaqData.Success.GetManyNewAsync(
            getManyOrderBy: ManyOrderBy.DateTime,
            orderByDirection: OrderByDirection.Descending,
            skip: (getManyNewRequest.Page - 1) * take,
            take: take);

        return new()
        {
            ResultCode = ResponseResultCode.Success,
            Records = getManyResult.Records.Select(m => new GetManyNewResponseRecord
            {
                DateTime = m.DateTime,
                Id = m.Id,
                InfaqId = m.InfaqId,
                UserId = m.UserId,
            }),
            Total = getManyResult.Total,
        };
    }
}
