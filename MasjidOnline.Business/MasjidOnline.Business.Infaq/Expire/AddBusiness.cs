using System;
using System.Threading.Tasks;
using MasjidOnline.Business.Authorization.Interface;
using MasjidOnline.Business.Infaq.Interface.Expire;
using MasjidOnline.Business.Infaq.Interface.Model.Expire;
using MasjidOnline.Business.Model.Options;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Data.Interface;
using MasjidOnline.Entity.Infaq;
using MasjidOnline.Library.Exceptions;
using MasjidOnline.Service.Interface;
using Microsoft.Extensions.Options;

namespace MasjidOnline.Business.Infaq.Expire;

public class AddBusiness(
    IOptionsMonitor<BusinessOptions> _optionsMonitor,
    IAuthorizationBusiness _authorizationBusiness,
    IService _service,
    IIdGenerator _idGenerator) : IAddBusiness
{
    public async Task<Response> AddAsync(IData _data, Session.Interface.Session session, AddRequest? addRequest)
    {
        await _authorizationBusiness.AuthorizePermissionAsync(session, _data, infaqExpireAdd: true);

        addRequest = _service.FieldValidator.ValidateRequired(addRequest);
        _service.FieldValidator.ValidateRequiredPlus(addRequest.InfaqId);


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
            UserId = session.UserId,
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
