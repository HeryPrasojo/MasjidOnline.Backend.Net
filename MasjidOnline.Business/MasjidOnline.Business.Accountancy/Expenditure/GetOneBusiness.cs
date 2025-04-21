using System.Threading.Tasks;
using MasjidOnline.Business.Accountancy.Expenditure.Mapper;
using MasjidOnline.Business.Accountancy.Interface.Expenditure;
using MasjidOnline.Business.Accountancy.Interface.Model.Expenditure;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Data.Interface;
using MasjidOnline.Library.Exceptions;
using MasjidOnline.Service.Interface;

namespace MasjidOnline.Business.Accountancy.Expenditure;

public class GetOneBusiness(IService _service) : IGetOneBusiness
{
    public async Task<GetOneResponse> GetAsync(IData _data, GetOneRequest? getOneRequest)
    {
        getOneRequest = _service.FieldValidator.ValidateRequired(getOneRequest);
        getOneRequest.Id = _service.FieldValidator.ValidateRequiredPlus(getOneRequest.Id);


        var expenditure = await _data.Accountancy.Expenditure.GetOneAsync(getOneRequest.Id.Value);

        if (expenditure == default) throw new InputMismatchException($"{nameof(getOneRequest.Id)}: {getOneRequest.Id}");

        return new()
        {
            ResultCode = ResponseResultCode.Success,
            DateTime = expenditure.DateTime,
            Status = expenditure.Status.ToModel(),
            UpdateDateTime = expenditure.UpdateDateTime,
            UpdateUserId = expenditure.UpdateUserId,
            UserId = expenditure.UserId,
        };
    }
}
