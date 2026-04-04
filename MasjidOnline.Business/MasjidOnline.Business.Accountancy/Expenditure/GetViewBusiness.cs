using System.Threading.Tasks;
using MasjidOnline.Business.Accountancy.Interface.Expenditure;
using MasjidOnline.Business.Model.Accountancy.Expenditure;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Data.Interface;
using MasjidOnline.Library.Exceptions;
using MasjidOnline.Service.Interface;

namespace MasjidOnline.Business.Accountancy.Expenditure;

public class GetViewBusiness(IService _service) : IGetViewBusiness
{
    public async Task<Response<GetViewResponse>> GetAsync(IData _data, GetViewRequest? getViewRequest)
    {
        getViewRequest = _service.FieldValidator.ValidateRequired(getViewRequest);
        getViewRequest.Id = _service.FieldValidator.ValidateRequiredPlus(getViewRequest.Id);


        var expenditure = await _data.Accountancy.Expenditure.GetFirstOrDefaultAsync(getViewRequest.Id.Value);

        if (expenditure == default) throw new InputMismatchException($"{nameof(getViewRequest.Id)}: {getViewRequest.Id}");

        return new()
        {
            ResultCode = ResponseResultCode.Success,
            Data = new()
            {
                DateTime = expenditure.DateTime,
                Status = Mapper.Mapper.Accountancy.ExpenditureStatus[expenditure.Status],
                UpdateDateTime = expenditure.UpdateDateTime,
                UpdateUserId = expenditure.UpdateUserId,
                UserId = expenditure.UserId,
            },
        };
    }
}
