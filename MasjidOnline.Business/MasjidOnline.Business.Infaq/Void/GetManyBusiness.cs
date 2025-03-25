using System.Linq;
using System.Threading.Tasks;
using MasjidOnline.Business.Infaq.Interface.Model.Void;
using MasjidOnline.Business.Infaq.Interface.Void;
using MasjidOnline.Business.Infaq.Void.Mapper;
using MasjidOnline.Business.Interface.Model.Responses;
using MasjidOnline.Data.Interface.Databases;
using MasjidOnline.Data.Interface.ViewModel.Infaq.Void;
using MasjidOnline.Data.Interface.ViewModel.Repository;
using MasjidOnline.Service.FieldValidator.Interface;

namespace MasjidOnline.Business.Infaq.Void;

public class GetManyBusiness(
    IFieldValidatorService _fieldValidatorService) : IGetManyBusiness
{
    public async Task<GetManyResponse<GetManyResponseRecord>> GetAsync(
        IInfaqDatabase _infaqDatabase,
        GetManyRequest? getManyRequest)
    {
        _fieldValidatorService.ValidateRequired(getManyRequest);
        _fieldValidatorService.ValidateRequiredPlus(getManyRequest!.Page);


        var take = 10;

        var getManyResult = await _infaqDatabase.Void.GetManyAsync(
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
