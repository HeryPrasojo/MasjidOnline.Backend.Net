using System;
using System.Threading.Tasks;
using MasjidOnline.Business.AuthorizationBusiness.Interface;
using MasjidOnline.Business.Infaq.Interface.Expire;
using MasjidOnline.Business.Infaq.Interface.Model.Expire;
using MasjidOnline.Business.Interface.Model.Options;
using MasjidOnline.Business.Interface.Model.Responses;
using MasjidOnline.Business.Session.Interface;
using MasjidOnline.Data.Interface.Datas;
using MasjidOnline.Data.Interface.IdGenerator;
using MasjidOnline.Entity.Infaq;
using MasjidOnline.Library.Exceptions;
using MasjidOnline.Service.FieldValidator.Interface;
using Microsoft.Extensions.Options;

namespace MasjidOnline.Business.Infaq.Expire;

public class AddBusiness(
    IOptionsMonitor<BusinessOptions> _optionsMonitor,
    IFieldValidatorService _fieldValidatorService,
    IInfaqIdGenerator _infaqIdGenerator) : IAddBusiness
{
    public async Task<Response> AddAsync(
        IAuthorizationBusiness _authorizationBusiness,
        IInfaqData _infaqData,
        ISessionBusiness _sessionBusiness,
        IUserData _userData,
        AddRequest addRequest)
    {
        await _authorizationBusiness.AuthorizePermissionAsync(_sessionBusiness, _userData, infaqExpireAdd: true);

        _fieldValidatorService.ValidateRequired(addRequest);
        _fieldValidatorService.ValidateRequiredPlus(addRequest.InfaqId);


        var any = await _infaqData.Expire.AnyAsync(addRequest.InfaqId, Entity.Infaq.ExpireStatus.New);

        if (any) throw new InputMismatchException(nameof(addRequest.InfaqId));


        var infaq = await _infaqData.Infaq.GetForExpireAddAsync(addRequest.InfaqId);

        if (infaq == default) throw new InputMismatchException(nameof(addRequest.InfaqId));

        if (infaq.PaymentStatus != PaymentStatus.New) throw new InputMismatchException(nameof(infaq.PaymentStatus));


        var expireDateTime = infaq.DateTime.AddDays(_optionsMonitor.CurrentValue.PaymentExpire);

        if (expireDateTime > DateTime.UtcNow) throw new InputMismatchException(nameof(infaq.DateTime));


        var expire = new Entity.Infaq.Expire
        {
            DateTime = DateTime.UtcNow,
            Id = _infaqIdGenerator.ExpireId,
            InfaqId = addRequest.InfaqId,
            Status = Entity.Infaq.ExpireStatus.New,
            UserId = _sessionBusiness.UserId,
        };

        await _infaqData.Expire.AddAsync(expire);

        _infaqData.Infaq.SetPaymentStatus(addRequest.InfaqId, PaymentStatus.ExpireRequest);

        await _infaqData.SaveAsync();

        // todo approver notification

        return new()
        {
            ResultCode = ResponseResultCode.Success,
        };
    }
}
