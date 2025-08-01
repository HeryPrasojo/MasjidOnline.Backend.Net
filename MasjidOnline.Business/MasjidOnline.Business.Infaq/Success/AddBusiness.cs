using System;
using System.Threading.Tasks;
using MasjidOnline.Business.Authorization.Interface;
using MasjidOnline.Business.Infaq.Interface.Model.Success;
using MasjidOnline.Business.Infaq.Interface.Success;
using MasjidOnline.Business.Model.Options;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Data.Interface;
using MasjidOnline.Entity.Infaq;
using MasjidOnline.Library.Exceptions;
using MasjidOnline.Service.Interface;
using Microsoft.Extensions.Options;

namespace MasjidOnline.Business.Infaq.Success;

public class AddBusiness(
    IOptionsMonitor<BusinessOptions> _optionsMonitor,
    IAuthorizationBusiness _authorizationBusiness,
    IService _service,
    IIdGenerator _idGenerator) : IAddBusiness
{
    public async Task<Response> AddAsync(IData _data, Session.Interface.Model.Session session, AddRequest? addRequest)
    {
        await _authorizationBusiness.Infaq.Success.AuthorizeAddAync(session, _data);

        addRequest = _service.FieldValidator.ValidateRequired(addRequest);
        addRequest.InfaqId = _service.FieldValidator.ValidateRequiredPlus(addRequest.InfaqId);


        var any = await _data.Infaq.Success.AnyAsync(addRequest.InfaqId.Value, Entity.Infaq.SuccessStatus.New);

        if (any) throw new InputMismatchException(nameof(addRequest.InfaqId));


        var infaq = await _data.Infaq.Infaq.GetForSuccessAddAsync(addRequest.InfaqId.Value);

        if (infaq == default) throw new InputMismatchException(nameof(addRequest.InfaqId));

        if (infaq.Status != InfaqStatus.New) throw new InputMismatchException(nameof(infaq.Status));


        var successDateTime = infaq.DateTime.AddDays(_optionsMonitor.CurrentValue.PaymentExpire);

        if (successDateTime > DateTime.UtcNow) throw new InputMismatchException(nameof(infaq.DateTime));


        var success = new Entity.Infaq.Success
        {
            DateTime = DateTime.UtcNow,
            Id = _idGenerator.Infaq.SuccessId,
            InfaqId = addRequest.InfaqId.Value,
            Status = Entity.Infaq.SuccessStatus.New,
            UserId = session.UserId,
        };

        await _data.Infaq.Success.AddAsync(success);

        _data.Infaq.Infaq.SetStatus(addRequest.InfaqId.Value, InfaqStatus.SuccessRequest);

        await _data.Infaq.SaveAsync();

        // todo wait approver notification

        return new()
        {
            ResultCode = ResponseResultCode.Success,
        };
    }
}
