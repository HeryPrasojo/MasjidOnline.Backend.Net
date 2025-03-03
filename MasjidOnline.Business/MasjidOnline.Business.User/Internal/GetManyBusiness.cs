using System.Linq;
using System.Threading.Tasks;
using MasjidOnline.Business.Interface.Model.Responses;
using MasjidOnline.Business.User.Interface.Internal;
using MasjidOnline.Business.User.Interface.Model.Internal;
using MasjidOnline.Data.Interface.Datas;
using MasjidOnline.Data.Interface.Model.Repository;
using MasjidOnline.Data.Interface.Model.User.Internal;
using MasjidOnline.Service.FieldValidator.Interface;

namespace MasjidOnline.Business.User.Internal;

public class GetManyBusiness(
    IFieldValidatorService _fieldValidatorService) : IGetManyBusiness
{
    public async Task<GetManyResponse<GetManyResponseRecord>> GetAsync(
        IUserData _userData,
        GetManyRequest getManyRequest)
    {
        _fieldValidatorService.ValidateRequired(getManyRequest);
        _fieldValidatorService.ValidateRequiredPlus(getManyRequest.Page);


        var take = 10;

        var getManyResult = await _userData.Internal.GetManyAsync(
            isApproved: getManyRequest.IsApproved,
            getManyOrderBy: GetManyOrderBy.DateTime,
            orderByDirection: OrderByDirection.Descending,
            skip: (getManyRequest.Page - 1) * take,
            take: take);

        return new()
        {
            ResultCode = ResponseResultCode.Success,
            Records = getManyResult.Records.Select(e => new GetManyResponseRecord
            {
                DateTime = e.DateTime,
                EmailAddress = e.EmailAddress,
                Id = e.Id,
                IsApproved = e.IsApproved,
                UpdateDateTime = e.UpdateDateTime,
                UpdateUserId = e.UpdateUserId,
                UserId = e.UserId,
            }),
            Total = getManyResult.Total,
        };
    }
}
