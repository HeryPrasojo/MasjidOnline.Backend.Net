using System.Threading.Tasks;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Business.User.Interface.Internal;
using MasjidOnline.Business.User.Interface.Model.Internal;
using MasjidOnline.Data.Interface;
using MasjidOnline.Library.Exceptions;
using MasjidOnline.Service.Interface;

namespace MasjidOnline.Business.User.Internal;

public class GetOneBusiness(IService _service) : IGetOneBusiness
{
    public async Task<Response<GetOneResponse>> GetAsync(IData _data, GetOneRequest? getOneRequest)
    {
        getOneRequest = _service.FieldValidator.ValidateRequired(getOneRequest);
        getOneRequest.Id = _service.FieldValidator.ValidateRequiredPlus(getOneRequest.Id);


        var @internal = await _data.User.InternalUser.GetOneAsync(getOneRequest.Id.Value);

        if (@internal == default) throw new InputMismatchException($"{nameof(getOneRequest.Id)}: {getOneRequest.Id}");

        return new()
        {
            ResultCode = ResponseResultCode.Success,
            Data = new()
            {
                DateTime = @internal.DateTime,
                Status = Mapper.Mapper.User.InternalUserStatus[@internal.Status],
                UpdateDateTime = @internal.UpdateDateTime,
                UpdateUserId = @internal.UpdateUserId,
                UserId = @internal.UserId,

            },
        };
    }
}
