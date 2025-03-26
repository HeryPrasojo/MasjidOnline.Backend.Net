using System.Linq;
using System.Threading.Tasks;
using MasjidOnline.Business.Infaq.Interface.Expire;
using MasjidOnline.Business.Infaq.Interface.Model.Expire;
using MasjidOnline.Business.Interface.Model.Responses;
using MasjidOnline.Data.Interface;
using MasjidOnline.Data.Interface.ViewModel.Infaq.Expire;
using MasjidOnline.Data.Interface.ViewModel.Repository;
using MasjidOnline.Service.FieldValidator.Interface;

namespace MasjidOnline.Business.Infaq.Expire;

public class GetManyNewBusiness(
    IFieldValidatorService _fieldValidatorService) : IGetManyNewBusiness
{
    public async Task<GetManyResponse<GetManyNewResponseRecord>> GetAsync(
        IData _data,
        GetManyNewRequest? getManyNewRequest)
    {
        _fieldValidatorService.ValidateRequired(getManyNewRequest);
        _fieldValidatorService.ValidateRequiredPlus(getManyNewRequest!.Page);


        var take = 10;

        var getManyResult = await _data.Infaq.Expire.GetManyNewAsync(
            getManyOrderBy: ManyOrderBy.DateTime,
            orderByDirection: OrderByDirection.Descending,
            skip: (getManyNewRequest.Page!.Value - 1) * take,
            take: take);

        return new()
        {
            ResultCode = ResponseResultCode.Success,
            Records = getManyResult.Records.Select(m => new GetManyNewResponseRecord
            {
                DateTime = m.DateTime,
                Id = m.InfaqId,
                InfaqId = m.InfaqId,
                UserId = m.UserId,
            }),
            Total = getManyResult.Total,
        };
    }
}
