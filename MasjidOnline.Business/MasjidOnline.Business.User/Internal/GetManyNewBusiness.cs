using System.Linq;
using System.Threading.Tasks;
using MasjidOnline.Business.Interface.Model.Responses;
using MasjidOnline.Business.User.Interface.Internal;
using MasjidOnline.Business.User.Interface.Model.Internal;
using MasjidOnline.Data.Interface.Datas;
using MasjidOnline.Data.Interface.ViewModel.Repository;
using MasjidOnline.Data.Interface.ViewModel.User.Internal;
using MasjidOnline.Service.FieldValidator.Interface;

namespace MasjidOnline.Business.User.Internal;

public class GetManyNewBusiness(
    IFieldValidatorService _fieldValidatorService) : IGetManyNewBusiness
{
    public async Task<GetManyResponse<GetManyNewResponseRecord>> GetAsync(
        IUserData _userData,
        GetManyNewRequest? getManyNewRequest)
    {
        _fieldValidatorService.ValidateRequired(getManyNewRequest);
        _fieldValidatorService.ValidateRequiredPlus(getManyNewRequest!.Page);


        var take = 10;

        var getManyResult = await _userData.Internal.GetManyNewAsync(
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
