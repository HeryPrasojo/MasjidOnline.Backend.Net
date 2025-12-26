using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using MasjidOnline.Business.Authorization.Interface;
using MasjidOnline.Business.Infaq.Interface.Infaq;
using MasjidOnline.Business.Model.Infaq.Infaq;
using MasjidOnline.Business.Model.Options;
using MasjidOnline.Business.Model.Payment;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Data.Interface;
using MasjidOnline.Entity.Infaq;
using MasjidOnline.Library.Exceptions;
using MasjidOnline.Service.Interface;
using Microsoft.Extensions.Options;

namespace MasjidOnline.Business.Infaq.Infaq;

public class AddByAnonymBusiness(
    IAuthorizationBusiness _authorizationBusiness,
    IService _service,
    IOptionsMonitor<BusinessOptions> _optionsMonitor) : Add, IAddByAnonymBusiness
{
    public async Task<Response> AddAsync(IData _data, Model.Session.Session session, AddByAnonymRequest? addByAnonymRequest)
    {
        _authorizationBusiness.AuthorizeAnonymous(session);

        addByAnonymRequest = _service.FieldValidator.ValidateRequired(addByAnonymRequest);
        addByAnonymRequest.CaptchaToken = _service.FieldValidator.ValidateRequired(addByAnonymRequest.CaptchaToken);
        addByAnonymRequest.Amount = _service.FieldValidator.ValidateRequiredPlus(addByAnonymRequest.Amount);
        addByAnonymRequest.PaymentType = _service.FieldValidator.ValidateRequiredEnum(addByAnonymRequest.PaymentType);
        addByAnonymRequest.MunfiqName = _service.FieldValidator.ValidateRequiredTextDb255(addByAnonymRequest.MunfiqName);
        addByAnonymRequest.ManualNotes = _service.FieldValidator.ValidateOptionalTextDb255(addByAnonymRequest.ManualNotes);


        var supportedPaymentTypes = new PaymentType[]
        {
            PaymentType.ManualBankTransfer,
        };

        if (!supportedPaymentTypes.Any(t => t == addByAnonymRequest.PaymentType)) throw new InputInvalidException(nameof(addByAnonymRequest.PaymentType));


        var manualPaymentTypes = new PaymentType[]
        {
            PaymentType.ManualBankTransfer,
        };

        if (manualPaymentTypes.Any(t => t == addByAnonymRequest.PaymentType))
        {
            addByAnonymRequest.ManualDateTime = _service.FieldValidator.ValidateRequiredPast(addByAnonymRequest.ManualDateTime);
        }


        var isCaptchaVerified = await _service.Captcha.VerifyInfaqAsync(addByAnonymRequest.CaptchaToken);

        if (!isCaptchaVerified) throw new InputMismatchException(nameof(addByAnonymRequest.CaptchaToken));


        await _data.Transaction.BeginAsync(_data.Infaq, _data.Payment);

        var infaq = new Entity.Infaq.Infaq
        {
            Id = _data.IdGenerator.Infaq.InfaqId,
            Amount = addByAnonymRequest.Amount.Value,
            DateTime = DateTime.UtcNow,
            Status = InfaqStatus.New,
            PaymentType = Mapper.Mapper.Payment.PaymentType[addByAnonymRequest.PaymentType.Value],
            UserId = session.UserId,
            MunfiqName = addByAnonymRequest.MunfiqName,
        };

        await _data.Infaq.Infaq.AddAsync(infaq);


        if (manualPaymentTypes.Any(t => t == addByAnonymRequest.PaymentType))
        {
            var infaqManual = new InfaqManual
            {
                InfaqId = infaq.Id,
                DateTime = addByAnonymRequest.ManualDateTime!.Value,
                Notes = addByAnonymRequest.ManualNotes,
            };

            await _data.Infaq.InfaqManual.AddAsync(infaqManual);
        }


        var temporaryFiles = new List<(string path, string temporaryPath)>();

        if (addByAnonymRequest.Files != default)
        {
            foreach (var file in addByAnonymRequest.Files)
            {
                var infaqFile = new InfaqFile
                {
                    Id = _data.IdGenerator.Infaq.InfaqFileId,
                    InfaqId = infaq.Id,
                };

                var fileName = infaqFile.Id;

                var path = _optionsMonitor.CurrentValue.Directory.Infaq + fileName;
                var temporaryPath = _optionsMonitor.CurrentValue.Directory.Infaq + '_' + fileName;


                await _service.File.CreateAsync(file, temporaryPath);

                await _data.Infaq.InfaqFile.AddAsync(infaqFile);

                temporaryFiles.Add((path, temporaryPath));
            }
        }


        await _data.Payment.ManualRecommendationId.SetUsedBySessionIdAsync(session.Id);

        await _data.Transaction.CommitAsync();

        foreach ((var path, var temporaryPath) in temporaryFiles)
            File.Move(temporaryPath, path, true);

        return new()
        {
            ResultCode = ResponseResultCode.Success,
        };
    }

    internal class TemporaryFile
    {
        public required string Path { get; set; }

        public required string TemporaryPath { get; set; }
    }
}
