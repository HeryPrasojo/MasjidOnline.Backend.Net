using System;
using System.Threading.Tasks;
using MasjidOnline.Business.Authorization.Interface;
using MasjidOnline.Business.Infaq.Interface.Model.Void;
using MasjidOnline.Business.Infaq.Interface.Void;
using MasjidOnline.Business.Model.Options;
using MasjidOnline.Business.Model.Responses;
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
    public async Task<Response> AddAsync(IData _data, Session.Interface.Model.Session session, AddRequest? addRequest)
    {
        await _authorizationBusiness.Infaq.Void.AuthorizeAddAync(session, _data);

        addRequest = _service.FieldValidator.ValidateRequired(addRequest);
        addRequest.InfaqId = _service.FieldValidator.ValidateRequiredPlus(addRequest.InfaqId);


        var any = await _data.Infaq.Void.AnyAsync(addRequest.InfaqId.Value, Entity.Infaq.VoidStatus.New);

        if (any) throw new InputMismatchException(nameof(addRequest.InfaqId));


        var infaq = await _data.Infaq.Infaq.GetForVoidAddAsync(addRequest.InfaqId.Value);

        if (infaq == default) throw new InputMismatchException(nameof(addRequest.InfaqId));

        if (infaq.Status != InfaqStatus.New) throw new InputMismatchException(nameof(infaq.Status));


        var voidDateTime = infaq.DateTime.AddDays(_optionsMonitor.CurrentValue.PaymentExpire);

        if (voidDateTime > DateTime.UtcNow) throw new InputMismatchException(nameof(infaq.DateTime));


        var @void = new Entity.Infaq.Void
        {
            DateTime = DateTime.UtcNow,
            Id = _idGenerator.Infaq.VoidId,
            InfaqId = addRequest.InfaqId.Value,
            Status = Entity.Infaq.VoidStatus.New,
            UserId = session.UserId,
        };

        await _data.Infaq.Void.AddAsync(@void);

        _data.Infaq.Infaq.SetStatus(addRequest.InfaqId.Value, InfaqStatus.VoidRequest);

        await _data.Infaq.SaveAsync();

        // todo wait notification approver

        return new()
        {
            ResultCode = ResponseResultCode.Success,
        };
    }
}
