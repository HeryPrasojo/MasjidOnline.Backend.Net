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

public class GetTableBusiness(IAuthorizationBusiness _authorizationBusiness, IService _service) : IGetTableBusiness
{
    public async Task<Response<TableResponse<TableResponseRecord>>> GetAsync(
        Model.Session.Session session,
        IData _data,
        TableRequest? getTableRequest)
    {
        await _authorizationBusiness.User.Internal.AuthorizeGetAync(session, _data);

        getTableRequest = _service.FieldValidator.ValidateRequired(getTableRequest);
        getTableRequest.Page = _service.FieldValidator.ValidateRequiredPlus(getTableRequest.Page);
        _service.FieldValidator.ValidateOptionalEnum(getTableRequest.Status);


        var take = 10;

        Entity.User.InternalUserStatus? requestStatus = getTableRequest.Status.HasValue ? Mapper.Mapper.User.InternalUserStatus[getTableRequest.Status.Value] : null;

        var getTableResult = await _data.User.InternalUser.GetTableAsync(
            status: requestStatus,
            getTableOrderBy: TableOrderBy.DateTime,
            orderByDirection: OrderByDirection.Descending,
            skip: (getTableRequest.Page.Value - 1) * take,
            take: take);


        var userIds = getTableResult.Records.Select(e => e.UserId);
        var addUserIds = getTableResult.Records.Select(e => e.AddUserId);

        var allUserIds = userIds.Concat(addUserIds);

        var persons = await _data.Person.Person.GetNamesAsync(allUserIds);


        return new()
        {
            ResultCode = ResponseResultCode.Success,
            Data = new()
            {
                PageCount = ((getTableResult.RecordCount - 1) / take) + 1,
                RecordCount = _service.Localization[getTableResult.RecordCount, session.CultureInfo],
                Records = getTableResult.Records.Select(e => new TableResponseRecord
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
