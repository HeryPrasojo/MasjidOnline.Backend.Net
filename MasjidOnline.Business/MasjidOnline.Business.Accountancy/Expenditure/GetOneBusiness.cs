using System.Threading.Tasks;
using MasjidOnline.Business.Accountancy.Interface.Expenditure;
using MasjidOnline.Business.Model.Accountancy.Expenditure;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Data.Interface;
using MasjidOnline.Library.Exceptions;
using MasjidOnline.Service.Interface;

namespace MasjidOnline.Business.Accountancy.Expenditure;

public class GetOneBusiness(IService _service) : IGetOneBusiness
{
    public async Task<Response<GetOneResponse>> GetAsync(IData _data, GetOneRequest? getOneRequest)
    {
        getOneRequest = _service.FieldValidator.ValidateRequired(getOneRequest);
        getOneRequest.Id = _service.FieldValidator.ValidateRequiredPlus(getOneRequest.Id);


        var expenditure = await _data.Accountancy.Expenditure.GetOneAsync(getOneRequest.Id.Value);

        if (expenditure == default) throw new InputMismatchException($"{nameof(getOneRequest.Id)}: {getOneRequest.Id}");

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
