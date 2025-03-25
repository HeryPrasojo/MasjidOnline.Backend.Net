using System.Linq;
using System.Threading.Tasks;
using MasjidOnline.Business.Interface.Model.Responses;
using MasjidOnline.Business.Session.Interface;
using MasjidOnline.Business.User.Interface.Internal;
using MasjidOnline.Business.User.Interface.Model.Internal;
using MasjidOnline.Business.User.Internal.Mapper;
using MasjidOnline.Data.Interface.Datas;
using MasjidOnline.Data.Interface.ViewModel.Repository;
using MasjidOnline.Data.Interface.ViewModel.User.Internal;
using MasjidOnline.Service.FieldValidator.Interface;

namespace MasjidOnline.Business.User.Internal;

public class GetManyBusiness(
    IFieldValidatorService _fieldValidatorService) : IGetManyBusiness
{
    public async Task<GetManyResponse<GetManyResponseRecord>> GetAsync(
        ISessionBusiness _sessionBusiness,
        IUserData _userData,
        GetManyRequest? getManyRequest)
    {
        _fieldValidatorService.ValidateRequired(getManyRequest);
        _fieldValidatorService.ValidateRequiredPlus(getManyRequest!.Page);


        var take = 10;

        var getManyResult = await _userData.Internal.GetManyAsync(
            status: getManyRequest.Status.ToEntity(),
            getManyOrderBy: ManyOrderBy.DateTime,
            orderByDirection: OrderByDirection.Descending,
            skip: (getManyRequest.Page!.Value - 1) * take,
            take: take);

        var type = await _userData.User.GetTypeAsync(_sessionBusiness.UserId);

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
