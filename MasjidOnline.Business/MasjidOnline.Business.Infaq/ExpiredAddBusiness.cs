using System;
using System.Threading.Tasks;
using MasjidOnline.Business.AuthorizationBusiness.Interface;
using MasjidOnline.Business.Infaq.Interface;
using MasjidOnline.Business.Infaq.Interface.Model.Infaq;
using MasjidOnline.Business.Interface.Model.Options;
using MasjidOnline.Business.Session.Interface;
using MasjidOnline.Data.Interface;
using MasjidOnline.Data.Interface.Datas;
using MasjidOnline.Entity.Infaqs;
using MasjidOnline.Library.Exceptions;
using MasjidOnline.Service.FieldValidator.Interface;
using Microsoft.Extensions.Options;

namespace MasjidOnline.Business.Infaq;

public class ExpiredAddBusiness(IOptionsMonitor<BusinessOptions> _optionsMonitor, IFieldValidatorService _fieldValidatorService) : IExpiredAddBusiness
{
    public async Task AddAsync(
        IAuthorizationBusiness _authorizationBusiness,
        IInfaqsData _infaqsData,
        ISessionBusiness _sessionBusiness,
        IDataTransaction _dataTransaction,
        IUsersData _usersData,
        ExpiredAddRequest expiredAddRequest)
    {
        await _authorizationBusiness.AuthorizePermissionAsync(_sessionBusiness, _usersData, infaqSetPaymentStatusExpired: true);

        _fieldValidatorService.ValidateRequired(expiredAddRequest);
        _fieldValidatorService.ValidateRequiredPlus(expiredAddRequest.Id);


        var infaq = await _infaqsData.Infaq.GetForExpiredAddAsync(expiredAddRequest.Id);

        if (infaq == default) throw new InputMismatchException(nameof(expiredAddRequest.Id));

        if (infaq.PaymentStatus != PaymentStatus.Pending) throw new InputMismatchException(nameof(infaq.PaymentStatus));


        var expiredDateTime = infaq.DateTime.AddDays(_optionsMonitor.CurrentValue.PaymentManualExpired);

        if (expiredDateTime > DateTime.UtcNow) throw new InputMismatchException(nameof(infaq.PaymentStatus));


        _dataTransaction.BeginAsync();
        _infaqsData.Expired.AddAsync();
        _infaqsData.Infaq.;
    }
}
