using System.Threading.Tasks;
using MasjidOnline.Business.Interface.Model.Responses;
using MasjidOnline.Business.User.Interface.Model.Internal;
using MasjidOnline.Data.Interface.Datas;
using MasjidOnline.Library.Exceptions;
using MasjidOnline.Service.FieldValidator.Interface;

namespace MasjidOnline.Business.User.Internal;

public class GetOneBusiness(
    IFieldValidatorService _fieldValidatorService) : IGetOneBusiness
{
    public async Task<GetOneResponse> GetAsync(
        IUserData _userData,
        GetOneRequest getOneRequest)
    {
        _fieldValidatorService.ValidateRequired(getOneRequest);
        _fieldValidatorService.ValidateRequiredPlus(getOneRequest.InfaqId);


        var infaq = await _userData.Internal.GetOneAsync(getOneRequest.InfaqId);

        if (infaq == default) throw new InputMismatchException($"{nameof(getOneRequest.InfaqId)}: {getOneRequest.InfaqId}");

        return new()
        {
            ResultCode = ResponseResultCode.Success,
            DateTime = infaq.DateTime,
            InfaqId = infaq.InfaqId,
            IsApproved = infaq.IsApproved,
            UpdateDateTime = infaq.UpdateDateTime,
            UpdateUserId = infaq.UpdateUserId,
            UserId = infaq.UserId,
        };
    }
}
