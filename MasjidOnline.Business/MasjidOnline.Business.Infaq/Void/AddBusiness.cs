using System;
using System.Threading.Tasks;
using MasjidOnline.Business.Authorization.Interface;
using MasjidOnline.Business.Infaq.Interface.Model.Void;
using MasjidOnline.Business.Infaq.Interface.Void;
using MasjidOnline.Business.Model.Options;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Business.Session.Interface;
using MasjidOnline.Data.Interface;
using MasjidOnline.Entity.Infaq;
using MasjidOnline.Library.Exceptions;
using MasjidOnline.Service.Interface;
using Microsoft.Extensions.Options;

namespace MasjidOnline.Business.Infaq.Void;

public class AddBusiness(
    IOptionsMonitor<BusinessOptions> _optionsMonitor,
    IAuthorizationBusiness _authorizationBusiness,
    IService _service,
    IIdGenerator _idGenerator) : IAddBusiness
{
    public async Task<Response> AddAsync(IData _data, ISessionBusiness _sessionBusiness, AddRequest? addRequest)
    {
        await _authorizationBusiness.AuthorizePermissionAsync(_sessionBusiness, _data, infaqVoidAdd: true);

        addRequest = _service.FieldValidator.ValidateRequired(addRequest);
        _service.FieldValidator.ValidateRequiredPlus(addRequest.InfaqId);


        var any = await _data.Infaq.Void.AnyAsync(addRequest.InfaqId!.Value, Entity.Infaq.VoidStatus.New);

        if (any) throw new InputMismatchException(nameof(addRequest.InfaqId));


        var infaq = await _data.Infaq.Infaq.GetForVoidAddAsync(addRequest.InfaqId.Value);

        if (infaq == default) throw new InputMismatchException(nameof(addRequest.InfaqId));

        if (infaq.PaymentStatus != PaymentStatus.New) throw new InputMismatchException(nameof(infaq.PaymentStatus));


        var voidDateTime = infaq.DateTime.AddDays(_optionsMonitor.CurrentValue.PaymentExpire);

        if (voidDateTime > DateTime.UtcNow) throw new InputMismatchException(nameof(infaq.DateTime));


        var @void = new Entity.Infaq.Void
        {
            DateTime = DateTime.UtcNow,
            Id = _idGenerator.Infaq.VoidId,
            InfaqId = addRequest.InfaqId.Value,
            Status = Entity.Infaq.VoidStatus.New,
            UserId = _sessionBusiness.UserId,
        };

        await _data.Infaq.Void.AddAsync(@void);

        _data.Infaq.Infaq.SetPaymentStatus(addRequest.InfaqId.Value, PaymentStatus.VoidRequest);

        await _data.Infaq.SaveAsync();

        // todo approver notification

        return new()
        {
            ResultCode = ResponseResultCode.Success,
        };
    }
}
