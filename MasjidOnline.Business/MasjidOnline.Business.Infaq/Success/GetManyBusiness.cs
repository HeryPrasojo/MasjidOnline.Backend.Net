using System.Linq;
using System.Threading.Tasks;
using MasjidOnline.Business.Infaq.Interface.Model.Success;
using MasjidOnline.Business.Infaq.Interface.Success;
using MasjidOnline.Business.Infaq.Success.Mapper;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Data.Interface;
using MasjidOnline.Data.Interface.ViewModel.Infaq.Success;
using MasjidOnline.Data.Interface.ViewModel.Repository;
using MasjidOnline.Service.Interface;

namespace MasjidOnline.Business.Infaq.Success;

public class GetManyBusiness(IService _service) : IGetManyBusiness
{
    public async Task<GetManyResponse<GetManyResponseRecord>> GetAsync(IData _data, GetManyRequest? getManyRequest)
    {
        getManyRequest = _service.FieldValidator.ValidateRequired(getManyRequest);
        _service.FieldValidator.ValidateRequiredPlus(getManyRequest.Page);


        var take = 10;

        var getManyResult = await _data.Infaq.Success.GetManyAsync(
            status: getManyRequest.Status.ToEntity(),
            getManyOrderBy: ManyOrderBy.DateTime,
            orderByDirection: OrderByDirection.Descending,
            skip: (getManyRequest.Page!.Value - 1) * take,
            take: take);

        return new()
        {
            ResultCode = ResponseResultCode.Success,
            Records = getManyResult.Records.Select(e => new GetManyResponseRecord
            {
                DateTime = e.DateTime,
                Id = e.Id,
                InfaqId = e.InfaqId,
                Status = e.Status.ToModel(),
                UpdateDateTime = e.UpdateDateTime,
                UpdateUserId = e.UpdateUserId,
                UserId = e.UserId,
            }),
            Total = getManyResult.Total,
        };
    }
}
