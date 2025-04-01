using System.Linq;
using System.Threading.Tasks;
using MasjidOnline.Business.Infaq.Interface.Model.Void;
using MasjidOnline.Business.Infaq.Interface.Void;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Data.Interface;
using MasjidOnline.Data.Interface.ViewModel.Infaq.Void;
using MasjidOnline.Data.Interface.ViewModel.Repository;
using MasjidOnline.Service.Interface;

namespace MasjidOnline.Business.Infaq.Void;

public class GetManyNewBusiness(IService _service) : IGetManyNewBusiness
{
    public async Task<GetManyResponse<GetManyNewResponseRecord>> GetAsync(IData _data, GetManyNewRequest? getManyUnprovedRequest)
    {
        _service.FieldValidator.ValidateRequired(getManyUnprovedRequest);
        _service.FieldValidator.ValidateRequiredPlus(getManyUnprovedRequest!.Page);


        var take = 10;

        var getManyResult = await _data.Infaq.Void.GetManyNewAsync(
            getManyOrderBy: ManyOrderBy.DateTime,
            orderByDirection: OrderByDirection.Descending,
            skip: (getManyUnprovedRequest.Page!.Value - 1) * take,
            take: take);

        return new()
        {
            ResultCode = ResponseResultCode.Success,
            Records = getManyResult.Records.Select(e => new GetManyNewResponseRecord
            {
                DateTime = e.DateTime,
                Id = e.Id,
                InfaqId = e.InfaqId,
                UserId = e.UserId,
            }),
            Total = getManyResult.Total,
        };
    }
}
