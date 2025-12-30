using System.Linq;
using System.Threading.Tasks;
using MasjidOnline.Business.Authorization.Interface;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Business.Model.User.Internal;
using MasjidOnline.Business.User.Interface.Internal;
using MasjidOnline.Data.Interface;
using MasjidOnline.Data.Interface.ViewModel.Repository;
using MasjidOnline.Data.Interface.ViewModel.User.Internal;
using MasjidOnline.Service.Interface;

namespace MasjidOnline.Business.User.Internal;

public class GetManyBusiness(IAuthorizationBusiness _authorizationBusiness, IService _service) : IGetManyBusiness
{
    public async Task<Response<GetManyResponse<GetManyResponseRecord>>> GetAsync(
        Model.Session.Session session,
        IData _data,
        GetManyRequest? getManyRequest)
    {
        await _authorizationBusiness.User.Internal.AuthorizeReadAync(session, _data);

        getManyRequest = _service.FieldValidator.ValidateRequired(getManyRequest);
        getManyRequest.Page = _service.FieldValidator.ValidateRequiredPlus(getManyRequest.Page);
        _service.FieldValidator.ValidateOptionalEnum(getManyRequest.Status);


        var take = 10;

        Entity.User.InternalUserStatus? requestStatus = getManyRequest.Status.HasValue ? Mapper.Mapper.User.InternalUserStatus[getManyRequest.Status.Value] : null;

        var getManyResult = await _data.User.InternalUser.GetManyAsync(
            status: requestStatus,
            getManyOrderBy: ManyOrderBy.DateTime,
            orderByDirection: OrderByDirection.Descending,
            skip: (getManyRequest.Page.Value - 1) * take,
            take: take);


        var userIds = getManyResult.Records.Select(e => e.UserId);
        var addUserIds = getManyResult.Records.Select(e => e.AddUserId);

        var allUserIds = userIds.Concat(addUserIds);

        var persons = await _data.Person.Person.GetNamesAsync(allUserIds);


        return new()
        {
            ResultCode = ResponseResultCode.Success,
            Data = new()
            {
                PageCount = ((getManyResult.RecordCount - 1) / take) + 1,
                RecordCount = _service.Localization[getManyResult.RecordCount, session.CultureInfo],
                Records = getManyResult.Records.Select(e => new GetManyResponseRecord
                {
                    AddPersonName = persons.FirstOrDefault(p => p.UserId == e.AddUserId)?.Name,
                    DateTime = _service.Localization[e.DateTime, session.CultureInfo, "yyyy MMM dd, HH:mm"],
                    Id = e.Id,
                    PersonName = persons.FirstOrDefault(p => p.UserId == e.UserId)?.Name,
                    Status = _service.Localization[Mapper.Mapper.User.InternalUserStatus[e.Status], session.CultureInfo],
                }),
            },
        };
    }
}
