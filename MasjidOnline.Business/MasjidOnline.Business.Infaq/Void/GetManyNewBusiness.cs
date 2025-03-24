using System.Linq;
using System.Threading.Tasks;
using MasjidOnline.Business.Infaq.Interface.Model.Void;
using MasjidOnline.Business.Infaq.Interface.Void;
using MasjidOnline.Business.Interface.Model.Responses;
using MasjidOnline.Data.Interface.Datas;
using MasjidOnline.Data.Interface.ViewModel.Infaq.Void;
using MasjidOnline.Data.Interface.ViewModel.Repository;
using MasjidOnline.Service.FieldValidator.Interface;

namespace MasjidOnline.Business.Infaq.Void;

public class GetManyNewBusiness(
    IFieldValidatorService _fieldValidatorService) : IGetManyNewBusiness
{
    public async Task<GetManyResponse<GetManyNewResponseRecord>> GetAsync(
        IInfaqData _infaqData,
        GetManyNewRequest? getManyUnprovedRequest)
    {
        _fieldValidatorService.ValidateRequired(getManyUnprovedRequest);
        _fieldValidatorService.ValidateRequiredPlus(getManyUnprovedRequest!.Page);


        var take = 10;

        var getManyResult = await _infaqData.Void.GetManyNewAsync(
            getManyOrderBy: ManyOrderBy.DateTime,
            orderByDirection: OrderByDirection.Descending,
            skip: (getManyUnprovedRequest.Page!.Value - 1) * take,
            take: take);

        return new()
        {
            ResultCode = ResponseResultCode.Success,
            Records = getManyResult.Records.Select(e => new GetManyNewResponseRecord
            {
                DateTime = e.DateTime,
                Id = e.Id,
                InfaqId = e.InfaqId,
                UserId = e.UserId,
            }),
            Total = getManyResult.Total,
        };
    }
}
