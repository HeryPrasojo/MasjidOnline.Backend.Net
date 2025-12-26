using System.Linq;
using System.Threading.Tasks;
using MasjidOnline.Business.Accountancy.Interface.Expenditure;
using MasjidOnline.Business.Model.Accountancy.Expenditure;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Data.Interface;
using MasjidOnline.Data.Interface.ViewModel.Accountancy.Expenditure;
using MasjidOnline.Data.Interface.ViewModel.Repository;
using MasjidOnline.Service.Interface;

namespace MasjidOnline.Business.Accountancy.Expenditure;

public class GetManyBusiness(IService _service) : IGetManyBusiness
{
    public async Task<Response<GetManyResponse<GetManyResponseRecord>>> GetAsync(
        IData _data,
        Model.Session.Session session,
        GetManyRequest? getManyRequest)
    {
        getManyRequest = _service.FieldValidator.ValidateRequired(getManyRequest);
        getManyRequest.Page = _service.FieldValidator.ValidateRequiredPlus(getManyRequest.Page);
        _service.FieldValidator.ValidateOptionalEnum(getManyRequest.Status);

        var take = 10;

        var getManyResult = await _data.Accountancy.Expenditure.GetManyAsync(
            status: getManyRequest.Status.HasValue ? Mapper.Mapper.Accountancy.ExpenditureStatus[getManyRequest.Status.Value] : default,
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
                    Amount = e.Amount,
                    DateTime = e.DateTime,
                    Description = e.Description,
                    Id = e.Id,
                    Status = Mapper.Mapper.Accountancy.ExpenditureStatus[e.Status],
                    StatusDescription = e.StatusDescription,
                    UpdateDateTime = e.UpdateDateTime,
                    UpdateUserId = e.UpdateUserId,
                    UserId = e.UserId,
                }),
            },
        };
    }
}
