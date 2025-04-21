using System.Threading.Tasks;
using MasjidOnline.Business.Infaq.Interface.Model.Void;
using MasjidOnline.Business.Infaq.Interface.Void;
using MasjidOnline.Business.Infaq.Void.Mapper;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Data.Interface;
using MasjidOnline.Library.Exceptions;
using MasjidOnline.Service.Interface;

namespace MasjidOnline.Business.Infaq.Void;

public class GetOneBusiness(IService _service) : IGetOneBusiness
{
    public async Task<GetOneResponse> GetAsync(IData _data, GetOneRequest? getOneRequest)
    {
        getOneRequest = _service.FieldValidator.ValidateRequired(getOneRequest);
        getOneRequest.Id = _service.FieldValidator.ValidateRequiredPlus(getOneRequest.Id);


        var infaq = await _data.Infaq.Void.GetOneAsync(getOneRequest.Id.Value);

        if (infaq == default) throw new InputMismatchException($"{nameof(getOneRequest.Id)}: {getOneRequest.Id}");

        return new()
        {
            ResultCode = ResponseResultCode.Success,
            DateTime = infaq.DateTime,
            Status = infaq.Status.ToModel(),
            UpdateDateTime = infaq.UpdateDateTime,
            UpdateUserId = infaq.UpdateUserId,
            UserId = infaq.UserId,
        };
    }
}
