using System;
using System.Threading.Tasks;
using MasjidOnline.Business.AuthorizationBusiness.Interface;
using MasjidOnline.Business.Infaq.Interface.Model.Success;
using MasjidOnline.Business.Infaq.Interface.Success;
using MasjidOnline.Business.Interface.Model.Options;
using MasjidOnline.Business.Interface.Model.Responses;
using MasjidOnline.Business.Session.Interface;
using MasjidOnline.Data.Interface.Datas;
using MasjidOnline.Data.Interface.IdGenerator;
using MasjidOnline.Entity.Infaq;
using MasjidOnline.Library.Exceptions;
using MasjidOnline.Service.FieldValidator.Interface;
using Microsoft.Extensions.Options;

namespace MasjidOnline.Business.Infaq.Success;

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
        await _authorizationBusiness.AuthorizePermissionAsync(_sessionBusiness, _userDatabase, infaqSuccessAdd: true);

        _fieldValidatorService.ValidateRequired(addRequest);
        _fieldValidatorService.ValidateRequiredPlus(addRequest!.InfaqId);


        var any = await _infaqDatabase.Success.AnyAsync(addRequest.InfaqId!.Value, Entity.Infaq.SuccessStatus.New);

        if (any) throw new InputMismatchException(nameof(addRequest.InfaqId));


        var infaq = await _infaqDatabase.Infaq.GetForSuccessAddAsync(addRequest.InfaqId.Value);

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

        await _infaqDatabase.Success.AddAsync(success);

        _infaqDatabase.Infaq.SetPaymentStatus(addRequest.InfaqId.Value, PaymentStatus.SuccessRequest);

        await _infaqDatabase.SaveAsync();

        // todo approver notification

        return new()
        {
            ResultCode = ResponseResultCode.Success,
        };
    }
}
