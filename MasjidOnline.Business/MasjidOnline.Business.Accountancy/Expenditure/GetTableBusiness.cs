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

public class GetTableBusiness(IService _service) : IGetTableBusiness
{
    public async Task<Response<TableResponse<TableResponseRecord>>> GetAsync(
        IData _data,
        Model.Session.Session session,
        TableRequest? getTableRequest)
    {
        getTableRequest = _service.FieldValidator.ValidateRequired(getTableRequest);
        getTableRequest.Page = _service.FieldValidator.ValidateRequiredPlus(getTableRequest.Page);
        _service.FieldValidator.ValidateOptionalEnum(getTableRequest.Status);

        var take = 10;

        var getTableResult = await _data.Accountancy.Expenditure.GetTableAsync(
            status: getTableRequest.Status.HasValue ? Mapper.Mapper.Accountancy.ExpenditureStatus[getTableRequest.Status.Value] : default,
            getTableOrderBy: TableOrderBy.DateTime,
            orderByDirection: OrderByDirection.Descending,
            skip: (getTableRequest.Page.Value - 1) * take,
            take: take);

        return new()
        {
            ResultCode = ResponseResultCode.Success,
            Data = new()
            {
                PageCount = ((getTableResult.RecordCount - 1) / take) + 1,
                RecordCount = _service.Localization[getTableResult.RecordCount, session.CultureInfo],
                Records = getTableResult.Records.Select(e => new TableResponseRecord
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
