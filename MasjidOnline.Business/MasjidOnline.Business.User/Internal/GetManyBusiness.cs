using System.Linq;
using System.Threading.Tasks;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Business.User.Interface.Internal;
using MasjidOnline.Business.User.Interface.Model.Internal;
using MasjidOnline.Business.User.Internal.Mapper;
using MasjidOnline.Data.Interface;
using MasjidOnline.Data.Interface.ViewModel.Repository;
using MasjidOnline.Data.Interface.ViewModel.User.Internal;
using MasjidOnline.Service.Interface;

namespace MasjidOnline.Business.User.Internal;

public class GetManyBusiness(IService _service) : IGetManyBusiness
{
    public async Task<GetManyResponse<GetManyResponseRecord>> GetAsync(Session.Interface.Session session, IData _data, GetManyRequest? getManyRequest)
    {
        getManyRequest = _service.FieldValidator.ValidateRequired(getManyRequest);
        _service.FieldValidator.ValidateRequiredPlus(getManyRequest.Page);


        var take = 10;

        var getManyResult = await _data.User.Internal.GetManyAsync(
            status: getManyRequest.Status.ToEntity(),
            getManyOrderBy: ManyOrderBy.DateTime,
            orderByDirection: OrderByDirection.Descending,
            skip: (getManyRequest.Page!.Value - 1) * take,
            take: take);

        var type = await _data.User.User.GetTypeAsync(session.UserId);

        return new()
        {
            ResultCode = ResponseResultCode.Success,
            Records = getManyResult.Records.Select(e => new GetManyResponseRecord
            {
                DateTime = e.DateTime,
                EmailAddress = (type == Entity.User.UserType.Internal) ? e.EmailAddress : default,
                Id = e.Id,
                Status = e.Status.ToModel(),
                UpdateDateTime = e.UpdateDateTime,
                UpdateUserId = e.UpdateUserId,
                UserId = e.UserId,
            }),
            Total = getManyResult.Total,
        };
    }
}
