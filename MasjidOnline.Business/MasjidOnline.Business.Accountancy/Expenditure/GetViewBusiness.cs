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
    public async Task<Response<ViewResponse>> GetAsync(IData _data, ViewRequest? viewRequest)
    {
        viewRequest = _service.FieldValidator.ValidateRequired(viewRequest);
        viewRequest.Id = _service.FieldValidator.ValidateRequiredPlus(viewRequest.Id);


        var expenditure = await _data.Accountancy.Expenditure.GetFirstOrDefaultAsync(viewRequest.Id.Value);

        if (expenditure == default) throw new InputMismatchException($"{nameof(viewRequest.Id)}: {viewRequest.Id}");

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
