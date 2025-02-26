using System.Threading.Tasks;
using MasjidOnline.Business.AuthorizationBusiness.Interface;
using MasjidOnline.Business.Infaq.Interface.Model.Infaq;
using MasjidOnline.Business.Session.Interface;
using MasjidOnline.Data.Interface.Datas;
using MasjidOnline.Library.Exceptions;
using MasjidOnline.Service.FieldValidator.Interface;

namespace MasjidOnline.Business.Infaq;

public class ExpiredAddBusiness(IFieldValidatorService _fieldValidatorService) : Interface.ExpiredAddBusiness
{
    public async Task AddAsync(
        IAuthorizationBusiness _authorizationBusiness,
        IInfaqsData _infaqsData,
        ISessionBusiness _sessionBusiness,
        IUsersData _usersData,
        ExpiredAddRequest expiredAddRequest)
    {
        await _authorizationBusiness.AuthorizePermissionAsync(_sessionBusiness, _usersData, infaqSetPaymentStatusExpired: true);

        _fieldValidatorService.ValidateRequired(expiredAddRequest);
        _fieldValidatorService.ValidateRequiredPlus(expiredAddRequest.Id);


        var infaq = await _infaqsData.Infaq.GetForExpiredAddAsync(expiredAddRequest.Id);

        if (infaq == default) throw new InputMismatchException(nameof(expiredAddRequest.Id));

        _infaqsData.Expired.AddAsync;
    }
}
