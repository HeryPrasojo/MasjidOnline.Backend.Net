using System.Threading.Tasks;
using MasjidOnline.Business.AuthorizationBusiness.Interface;
using MasjidOnline.Business.Infaq.Interface;
using MasjidOnline.Business.Infaq.Interface.Model.Infaq;
using MasjidOnline.Business.Session.Interface;
using MasjidOnline.Data.Interface.Datas;
using MasjidOnline.Service.FieldValidator.Interface;

namespace MasjidOnline.Business.Infaq;

public class InfaqSetPaymentStatusExpiredBusiness(IFieldValidatorService _fieldValidatorService) : IInfaqSetPaymentStatusExpiredBusiness
{
    public async Task SetAsync(
        IAuthorizationBusiness _authorizationBusiness,
        IInfaqsData _infaqsData,
        ISessionBusiness _sessionBusiness,
        IUsersData _usersData,
        SetPaymentStatusExpiredRequest setPaymentStatusExpiredRequest)
    {
        await _authorizationBusiness.AuthorizePermissionAsync(_sessionBusiness, _usersData, infaqSetPaymentStatusExpired: true);

        _fieldValidatorService.ValidateRequired(setPaymentStatusExpiredRequest);
        _fieldValidatorService.ValidateRequiredPlus(setPaymentStatusExpiredRequest.Id);

        var infaq = await _infaqsData.Infaq.GetOneByIdAsync();
        _infaqsData.Expired.AddAsync;
    }
}
