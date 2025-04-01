using System.Linq;
using System.Threading.Tasks;
using MasjidOnline.Business.Infaq.Interface.Model.Success;
using MasjidOnline.Business.Infaq.Interface.Success;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Data.Interface;
using MasjidOnline.Data.Interface.ViewModel.Infaq.Success;
using MasjidOnline.Data.Interface.ViewModel.Repository;
using MasjidOnline.Service.Interface;

namespace MasjidOnline.Business.Infaq.Success;

public class GetManyNewBusiness(IService _service) : IGetManyNewBusiness
{
    public async Task<GetManyResponse<GetManyNewResponseRecord>> GetAsync(IData _data, GetManyNewRequest? getManyNewRequest)
    {
        _service.FieldValidator.ValidateRequired(getManyNewRequest);
        _service.FieldValidator.ValidateRequiredPlus(getManyNewRequest!.Page);


        var take = 10;

        var getManyResult = await _data.Infaq.Success.GetManyNewAsync(
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
                Id = m.Id,
                InfaqId = m.InfaqId,
                UserId = m.UserId,
            }),
            Total = getManyResult.Total,
        };
    }
}
