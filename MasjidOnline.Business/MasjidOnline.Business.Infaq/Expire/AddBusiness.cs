using System;
using System.Threading.Tasks;
using MasjidOnline.Business.Authorization.Interface;
using MasjidOnline.Business.Infaq.Interface.Expire;
using MasjidOnline.Business.Infaq.Interface.Model.Expire;
using MasjidOnline.Business.Model.Options;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Business.Session.Interface;
using MasjidOnline.Data.Interface;
using MasjidOnline.Entity.Infaq;
using MasjidOnline.Library.Exceptions;
using MasjidOnline.Service.FieldValidator.Interface;
using Microsoft.Extensions.Options;

namespace MasjidOnline.Business.Infaq.Expire;

public class AddBusiness(
    IOptionsMonitor<BusinessOptions> _optionsMonitor,
    IAuthorizationBusiness _authorizationBusiness,
    IFieldValidatorService _fieldValidatorService,
    IIdGenerator _idGenerator) : IAddBusiness
{
    public async Task<Response> AddAsync(
        IData _data,
        ISessionBusiness _sessionBusiness,
        AddRequest? addRequest)
    {
        await _authorizationBusiness.AuthorizePermissionAsync(_sessionBusiness, _data, infaqExpireAdd: true);

        _fieldValidatorService.ValidateRequired(addRequest);
        _fieldValidatorService.ValidateRequiredPlus(addRequest!.InfaqId);


        var any = await _data.Infaq.Expire.AnyAsync(addRequest.InfaqId!.Value, Entity.Infaq.ExpireStatus.New);

        if (any) throw new InputMismatchException(nameof(addRequest.InfaqId));


        var infaq = await _data.Infaq.Infaq.GetForExpireAddAsync(addRequest.InfaqId.Value);

        if (infaq == default) throw new InputMismatchException(nameof(addRequest.InfaqId));

        if (infaq.PaymentStatus != PaymentStatus.New) throw new InputMismatchException(nameof(infaq.PaymentStatus));


        var expireDateTime = infaq.DateTime.AddDays(_optionsMonitor.CurrentValue.PaymentExpire);

        if (expireDateTime > DateTime.UtcNow) throw new InputMismatchException(nameof(infaq.DateTime));


        var expire = new Entity.Infaq.Expire
        {
            DateTime = DateTime.UtcNow,
            Id = _idGenerator.Infaq.ExpireId,
            InfaqId = addRequest.InfaqId.Value,
            Status = Entity.Infaq.ExpireStatus.New,
            UserId = _sessionBusiness.UserId,
        };

        await _data.Infaq.Expire.AddAsync(expire);

        _data.Infaq.Infaq.SetPaymentStatus(addRequest.InfaqId.Value, PaymentStatus.ExpireRequest);

        await _data.Infaq.SaveAsync();

        // todo approver notification

        return new()
        {
            ResultCode = ResponseResultCode.Success,
        };
    }
}
