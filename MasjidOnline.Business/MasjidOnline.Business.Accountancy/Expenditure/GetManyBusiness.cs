using System.Linq;
using System.Threading.Tasks;
using MasjidOnline.Business.Accountancy.Expenditure.Mapper;
using MasjidOnline.Business.Accountancy.Interface.Expenditure;
using MasjidOnline.Business.Accountancy.Interface.Model.Expenditure;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Data.Interface;
using MasjidOnline.Data.Interface.ViewModel.Accountancy.Expenditure;
using MasjidOnline.Data.Interface.ViewModel.Repository;
using MasjidOnline.Service.Interface;

namespace MasjidOnline.Business.Accountancy.Expenditure;

public class GetManyBusiness(IService _service) : IGetManyBusiness
{
    public async Task<GetManyResponse<GetManyResponseRecord>> GetAsync(Session.Interface.Model.Session session, IData _data, GetManyRequest? getManyRequest)
    {
        getManyRequest = _service.FieldValidator.ValidateRequired(getManyRequest);
        _service.FieldValidator.ValidateRequiredPlus(getManyRequest.Page);


        var take = 10;

        var getManyResult = await _data.Accountancy.Expenditure.GetManyAsync(
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
                Status = e.Status.ToModel(),
                UpdateDateTime = e.UpdateDateTime,
                UpdateExpenditureId = e.UpdateExpenditureId,
                ExpenditureId = e.ExpenditureId,
            }),
            Total = getManyResult.Total,
        };
    }
}
