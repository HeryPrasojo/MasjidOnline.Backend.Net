using System;
using System.Threading.Tasks;
using MasjidOnline.Business.AuthorizationBusiness.Interface;
using MasjidOnline.Business.Infaq.Interface.Model.Void;
using MasjidOnline.Business.Infaq.Interface.Void;
using MasjidOnline.Business.Interface.Model.Options;
using MasjidOnline.Business.Interface.Model.Responses;
using MasjidOnline.Business.Session.Interface;
using MasjidOnline.Data.Interface.Datas;
using MasjidOnline.Data.Interface.IdGenerator;
using MasjidOnline.Entity.Infaq;
using MasjidOnline.Library.Exceptions;
using MasjidOnline.Service.FieldValidator.Interface;
using Microsoft.Extensions.Options;

namespace MasjidOnline.Business.Infaq.Void;

public class AddBusiness(
    IOptionsMonitor<BusinessOptions> _optionsMonitor,
    IFieldValidatorService _fieldValidatorService,
    IInfaqIdGenerator _infaqIdGenerator) : IAddBusiness
{
    public async Task<Response> AddAsync(
        IAuthorizationBusiness _authorizationBusiness,
        IInfaqDatabase _infaqDatabase,
        ISessionBusiness _sessionBusiness,
        IUserDatabase _userDatabase,
        AddRequest? addRequest)
    {
        await _authorizationBusiness.AuthorizePermissionAsync(_sessionBusiness, _userDatabase, infaqVoidAdd: true);

        _fieldValidatorService.ValidateRequired(addRequest);
        _fieldValidatorService.ValidateRequiredPlus(addRequest!.InfaqId);


        var any = await _infaqDatabase.Void.AnyAsync(addRequest.InfaqId!.Value, Entity.Infaq.VoidStatus.New);

        if (any) throw new InputMismatchException(nameof(addRequest.InfaqId));


        var infaq = await _infaqDatabase.Infaq.GetForVoidAddAsync(addRequest.InfaqId.Value);

        if (infaq == default) throw new InputMismatchException(nameof(addRequest.InfaqId));

        if (infaq.PaymentStatus != PaymentStatus.New) throw new InputMismatchException(nameof(infaq.PaymentStatus));


        var voidDateTime = infaq.DateTime.AddDays(_optionsMonitor.CurrentValue.PaymentExpire);

        if (voidDateTime > DateTime.UtcNow) throw new InputMismatchException(nameof(infaq.DateTime));


        var @void = new Entity.Infaq.Void
        {
            DateTime = DateTime.UtcNow,
            Id = _infaqIdGenerator.VoidId,
            InfaqId = addRequest.InfaqId.Value,
            Status = Entity.Infaq.VoidStatus.New,
            UserId = _sessionBusiness.UserId,
        };

        await _infaqDatabase.Void.AddAsync(@void);

        _infaqDatabase.Infaq.SetPaymentStatus(addRequest.InfaqId.Value, PaymentStatus.VoidRequest);

        await _infaqDatabase.SaveAsync();

        // todo approver notification

        return new()
        {
            ResultCode = ResponseResultCode.Success,
        };
    }
}
