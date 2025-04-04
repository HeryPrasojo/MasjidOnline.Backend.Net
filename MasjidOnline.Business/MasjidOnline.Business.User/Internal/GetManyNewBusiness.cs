using System.Linq;
using System.Threading.Tasks;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Business.User.Interface.Internal;
using MasjidOnline.Business.User.Interface.Model.Internal;
using MasjidOnline.Data.Interface;
using MasjidOnline.Data.Interface.ViewModel.Repository;
using MasjidOnline.Data.Interface.ViewModel.User.Internal;
using MasjidOnline.Service.Interface;

namespace MasjidOnline.Business.User.Internal;

public class GetManyNewBusiness(IService _service) : IGetManyNewBusiness
{
    public async Task<GetManyResponse<GetManyNewResponseRecord>> GetAsync(IData _data, GetManyNewRequest? getManyNewRequest)
    {
        getManyNewRequest = _service.FieldValidator.ValidateRequired(getManyNewRequest);
        _service.FieldValidator.ValidateRequiredPlus(getManyNewRequest.Page);


        var take = 10;

        var getManyResult = await _data.User.Internal.GetManyNewAsync(
            getManyOrderBy: ManyOrderBy.DateTime,
            orderByDirection: OrderByDirection.Descending,
            skip: (getManyNewRequest.Page!.Value - 1) * take,
            take: take);

        return new()
        {
            ResultCode = ResponseResultCode.Success,
            Records = getManyResult.Records.Select(e => new GetManyNewResponseRecord
            {
                DateTime = e.DateTime,
                Description = e.Description,
                EmailAddress = e.EmailAddress,
                UserId = e.UserId,
            }),
            Total = getManyResult.Total,
        };
    }
}
