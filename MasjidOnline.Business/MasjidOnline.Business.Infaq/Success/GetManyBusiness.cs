using System.Linq;
using System.Threading.Tasks;
using MasjidOnline.Business.Infaq.Interface.Model.Success;
using MasjidOnline.Business.Infaq.Interface.Success;
using MasjidOnline.Business.Infaq.Success.Mapper;
using MasjidOnline.Business.Interface.Model.Responses;
using MasjidOnline.Data.Interface.Datas;
using MasjidOnline.Data.Interface.ViewModel.Infaq.Success;
using MasjidOnline.Data.Interface.ViewModel.Repository;
using MasjidOnline.Service.FieldValidator.Interface;

namespace MasjidOnline.Business.Infaq.Success;

public class GetManyBusiness(
    IFieldValidatorService _fieldValidatorService) : IGetManyBusiness
{
    public async Task<GetManyResponse<GetManyResponseRecord>> GetAsync(
        IInfaqData _infaqData,
        GetManyRequest getManyRequest)
    {
        _fieldValidatorService.ValidateRequired(getManyRequest);
        _fieldValidatorService.ValidateRequiredPlus(getManyRequest.Page);


        var take = 10;

        var getManyResult = await _infaqData.Success.GetManyAsync(
            status: getManyRequest.Status.ToEntity(),
            getManyOrderBy: ManyOrderBy.DateTime,
            orderByDirection: OrderByDirection.Descending,
            skip: (getManyRequest.Page - 1) * take,
            take: take);

        return new()
        {
            ResultCode = ResponseResultCode.Success,
            Records = getManyResult.Records.Select(e => new GetManyResponseRecord
            {
                DateTime = e.DateTime,
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
