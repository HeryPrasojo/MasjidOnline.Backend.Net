using System;
using System.Threading.Tasks;
using MasjidOnline.Business.AuthorizationBusiness.Interface;
using MasjidOnline.Business.Infaq.Interface.Expired;
using MasjidOnline.Business.Infaq.Interface.Model.Expired;
using MasjidOnline.Business.Interface.Model.Options;
using MasjidOnline.Business.Interface.Model.Responses;
using MasjidOnline.Business.Session.Interface;
using MasjidOnline.Data.Interface.Datas;
using MasjidOnline.Entity.Infaq;
using MasjidOnline.Library.Exceptions;
using MasjidOnline.Service.FieldValidator.Interface;
using Microsoft.Extensions.Options;

namespace MasjidOnline.Business.Infaq.Expired;

public class AddBusiness(
    IOptionsMonitor<BusinessOptions> _optionsMonitor,
    IFieldValidatorService _fieldValidatorService) : IAddBusiness
{
    public async Task<Response> AddAsync(
        IAuthorizationBusiness _authorizationBusiness,
        IInfaqData _infaqData,
        ISessionBusiness _sessionBusiness,
        IUserData _userData,
        AddRequest addRequest)
    {
        await _authorizationBusiness.AuthorizePermissionAsync(_sessionBusiness, _userData, infaqSetPaymentStatusExpired: true);

        _fieldValidatorService.ValidateRequired(addRequest);
        _fieldValidatorService.ValidateRequiredPlus(addRequest.Id);


        var infaq = await _infaqData.Infaq.GetForExpiredAddAsync(addRequest.Id);

        if (infaq == default) throw new InputMismatchException(nameof(addRequest.Id));

        if (infaq.PaymentStatus != PaymentStatus.Pending) throw new InputMismatchException(nameof(infaq.PaymentStatus));


        var expiredDateTime = infaq.DateTime.AddDays(_optionsMonitor.CurrentValue.PaymentManualExpired);

        if (expiredDateTime > DateTime.UtcNow) throw new InputMismatchException(nameof(infaq.DateTime));


        var expired = new Entity.Infaq.Expired
        {
            DateTime = DateTime.UtcNow,
            InfaqId = addRequest.Id,
            UserId = _sessionBusiness.UserId,
        };

        await _infaqData.Expired.AddAsync(expired);

        _infaqData.Infaq.UpdatePaymentStatus(addRequest.Id, PaymentStatus.Expire);


        //var expired = new Payment
        //{
        //    DateTime = DateTime.UtcNow,
        //    InfaqId = expiredAddRequest.Id,
        //    UserId = _sessionBusiness.UserId,
        //};

        //_infaqData.Payment.AddAsync();

        await _infaqData.SaveAsync();

        // todo approver notification


        return new()
        {
            ResultCode = ResponseResultCode.Success,
        };
    }
}
