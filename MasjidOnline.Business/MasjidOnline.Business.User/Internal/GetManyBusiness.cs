using System.Linq;
using System.Threading.Tasks;
using MasjidOnline.Business.Authorization.Interface;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Business.User.Interface.Internal;
using MasjidOnline.Business.User.Interface.Model.Internal;
using MasjidOnline.Data.Interface;
using MasjidOnline.Data.Interface.ViewModel.Repository;
using MasjidOnline.Data.Interface.ViewModel.User.Internal;
using MasjidOnline.Service.Interface;

namespace MasjidOnline.Business.User.Internal;

public class GetManyBusiness(IAuthorizationBusiness _authorizationBusiness, IService _service) : IGetManyBusiness
{
    public async Task<Response<GetManyResponse<GetManyResponseRecord>>> GetAsync(
        Session.Interface.Model.Session session,
        IData _data,
        GetManyRequest? getManyRequest)
    {
        await _authorizationBusiness.User.Internal.AuthorizeReadAync(session, _data);

        getManyRequest = _service.FieldValidator.ValidateRequired(getManyRequest);
        getManyRequest.Page = _service.FieldValidator.ValidateRequiredPlus(getManyRequest.Page);
        _service.FieldValidator.ValidateOptionalEnum(getManyRequest.Status);


        var take = 10;

        var requestStatus = getManyRequest.Status.HasValue ? Mapper.Mapper.User.InternalUserStatus[getManyRequest.Status.Value] : default;

        var getManyResult = await _data.User.InternalUser.GetManyAsync(
            status: requestStatus,
            getManyOrderBy: ManyOrderBy.DateTime,
            orderByDirection: OrderByDirection.Descending,
            skip: (getManyRequest.Page.Value - 1) * take,
            take: take);

        return new()
        {
            ResultCode = ResponseResultCode.Success,
            Data = new()
            {
                PageCount = ((getManyResult.RecordCount - 1) / take) + 1,
                RecordCount = _service.Localization[getManyResult.RecordCount, session.CultureInfo],
                Records = getManyResult.Records.Select(e => new GetManyResponseRecord
                {
                    DateTime = e.DateTime,
                    Id = e.Id,
                    Status = Mapper.Mapper.User.InternalUserStatus[e.Status],
                    UpdateDateTime = e.UpdateDateTime,
                    UpdateUserId = e.UpdateUserId,
                    UserId = e.UserId,
                }),
            },
        };
    }
}
