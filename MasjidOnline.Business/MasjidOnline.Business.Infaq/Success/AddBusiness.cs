using System;
using System.Threading.Tasks;
using MasjidOnline.Business.Authorization.Interface;
using MasjidOnline.Business.Infaq.Interface.Model.Success;
using MasjidOnline.Business.Infaq.Interface.Success;
using MasjidOnline.Business.Model.Options;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Business.Session.Interface;
using MasjidOnline.Data.Interface;
using MasjidOnline.Data.Interface.IdGenerator;
using MasjidOnline.Entity.Infaq;
using MasjidOnline.Library.Exceptions;
using MasjidOnline.Service.FieldValidator.Interface;
using Microsoft.Extensions.Options;

namespace MasjidOnline.Business.Infaq.Success;

public class AddBusiness(
    IOptionsMonitor<BusinessOptions> _optionsMonitor,
    IAuthorizationBusiness _authorizationBusiness,
    IFieldValidatorService _fieldValidatorService,
    IInfaqIdGenerator _infaqIdGenerator) : IAddBusiness
{
    public async Task<Response> AddAsync(
        IData _data,
        ISessionBusiness _sessionBusiness,
        AddRequest? addRequest)
    {
        await _authorizationBusiness.AuthorizePermissionAsync(_sessionBusiness, _data, infaqSuccessAdd: true);

        _fieldValidatorService.ValidateRequired(addRequest);
        _fieldValidatorService.ValidateRequiredPlus(addRequest!.InfaqId);


        var any = await _data.Infaq.Success.AnyAsync(addRequest.InfaqId!.Value, Entity.Infaq.SuccessStatus.New);

        if (any) throw new InputMismatchException(nameof(addRequest.InfaqId));


        var infaq = await _data.Infaq.Infaq.GetForSuccessAddAsync(addRequest.InfaqId.Value);

        if (infaq == default) throw new InputMismatchException(nameof(addRequest.InfaqId));

        if (infaq.PaymentStatus != PaymentStatus.New) throw new InputMismatchException(nameof(infaq.PaymentStatus));


        var successDateTime = infaq.DateTime.AddDays(_optionsMonitor.CurrentValue.PaymentExpire);

        if (successDateTime > DateTime.UtcNow) throw new InputMismatchException(nameof(infaq.DateTime));


        var success = new Entity.Infaq.Success
        {
            DateTime = DateTime.UtcNow,
            Id = _infaqIdGenerator.SuccessId,
            InfaqId = addRequest.InfaqId.Value,
            Status = Entity.Infaq.SuccessStatus.New,
            UserId = _sessionBusiness.UserId,
        };

        await _data.Infaq.Success.AddAsync(success);

        _data.Infaq.Infaq.SetPaymentStatus(addRequest.InfaqId.Value, PaymentStatus.SuccessRequest);

        await _data.Infaq.SaveAsync();

        // todo approver notification

        return new()
        {
            ResultCode = ResponseResultCode.Success,
        };
    }
}
