using System.Threading.Tasks;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Business.User.Interface.Internal;
using MasjidOnline.Business.User.Interface.Model.Internal;
using MasjidOnline.Business.User.Internal.Mapper;
using MasjidOnline.Data.Interface;
using MasjidOnline.Library.Exceptions;
using MasjidOnline.Service.Interface;

namespace MasjidOnline.Business.User.Internal;

public class GetOneBusiness(IService _service) : IGetOneBusiness
{
    public async Task<GetOneResponse> GetAsync(IData _data, GetOneRequest? getOneRequest)
    {
        getOneRequest = _service.FieldValidator.ValidateRequired(getOneRequest);
        _service.FieldValidator.ValidateRequiredPlus(getOneRequest.Id);


        var @internal = await _data.User.Internal.GetOneAsync(getOneRequest.Id!.Value);

        if (@internal == default) throw new InputMismatchException($"{nameof(getOneRequest.Id)}: {getOneRequest.Id}");

        return new()
        {
            ResultCode = ResponseResultCode.Success,
            DateTime = @internal.DateTime,
            Status = @internal.Status.ToModel(),
            UpdateDateTime = @internal.UpdateDateTime,
            UpdateUserId = @internal.UpdateUserId,
            UserId = @internal.UserId,
        };
    }
}
