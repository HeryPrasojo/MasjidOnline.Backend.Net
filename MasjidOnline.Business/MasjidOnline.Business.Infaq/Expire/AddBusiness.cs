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
    IService _service) : IAddBusiness
{
    public async Task<Response> AddAsync(IData _data, Session.Interface.Model.Session session, AddRequest? addRequest)
    {
        await _authorizationBusiness.Infaq.Expire.AuthorizeAddAync(session, _data);

        addRequest = _service.FieldValidator.ValidateRequired(addRequest);
        addRequest.InfaqId = _service.FieldValidator.ValidateRequiredPlus(addRequest.InfaqId);


        var any = await _data.Infaq.Expire.AnyAsync(addRequest.InfaqId.Value, Entity.Infaq.ExpireStatus.New);

        if (any) throw new InputMismatchException(nameof(addRequest.InfaqId));


        var infaq = await _data.Infaq.Infaq.GetForExpireAddAsync(addRequest.InfaqId.Value);

        if (infaq == default) throw new InputMismatchException(nameof(addRequest.InfaqId));

        if (infaq.Status != InfaqStatus.New) throw new InputMismatchException(nameof(infaq.Status));


        var expireDateTime = infaq.DateTime.AddDays(_optionsMonitor.CurrentValue.PaymentExpire);

        if (expireDateTime > DateTime.UtcNow) throw new InputMismatchException(nameof(infaq.DateTime));


        var expire = new Entity.Infaq.Expire
        {
            DateTime = DateTime.UtcNow,
            Id = _data.IdGenerator.Infaq.ExpireId,
            InfaqId = addRequest.InfaqId.Value,
            Status = Entity.Infaq.ExpireStatus.New,
            UserId = session.UserId,
        };

        await _data.Infaq.Expire.AddAsync(expire);

        _data.Infaq.Infaq.SetStatus(addRequest.InfaqId.Value, InfaqStatus.ExpireRequest);

        await _data.Infaq.SaveAsync();

        // todo wait notification approver

        return new()
        {
            ResultCode = ResponseResultCode.Success,
        };
    }
}
