using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using MasjidOnline.Business.Infaq.Infaq.Mapper;
using MasjidOnline.Business.Infaq.Interface.Infaq;
using MasjidOnline.Business.Infaq.Interface.Model.Infaq;
using MasjidOnline.Business.Model.Options;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Data.Interface;
using MasjidOnline.Entity.Captcha;
using MasjidOnline.Entity.Infaq;
using MasjidOnline.Entity.Payment;
using MasjidOnline.Library.Exceptions;
using MasjidOnline.Service.Interface;
using Microsoft.Extensions.Options;

namespace MasjidOnline.Business.Infaq.Infaq;

public class AddByAnonymBusiness(IService _service, IIdGenerator _idGenerator, IOptionsMonitor<BusinessOptions> _optionsMonitor) : Add, IAddByAnonymBusiness
{
    public async Task<Response> AddAsync(IData _data, Session.Interface.Model.Session session, AddByAnonymRequest? addByAnonymRequest)
    {
        addByAnonymRequest = _service.FieldValidator.ValidateRequired(addByAnonymRequest);

        var utcNow = DateTime.UtcNow;

        if (session.IsUserAnonymous)
        {
            var any = await _data.Captcha.Pass.AnyAsync(session.Id);

            if (!any)
            {
                addByAnonymRequest.CaptchaToken = _service.FieldValidator.ValidateRequired(addByAnonymRequest.CaptchaToken);

                var isVerified = await _service.Captcha.VerifyAsync(addByAnonymRequest.CaptchaToken, "infaq");

                if (!isVerified) throw new InputMismatchException(nameof(addByAnonymRequest.CaptchaToken));


                var pass = new Pass
                {
                    DateTime = utcNow,
                    SessionId = session.Id,
                };

                await _data.Captcha.Pass.AddAndSaveAsync(pass);
            }
        }


        addByAnonymRequest.Amount = _service.FieldValidator.ValidateRequiredPlus(addByAnonymRequest.Amount);
        addByAnonymRequest.PaymentType = (Payment.Interface.Model.PaymentType)_service.FieldValidator.ValidateRequired(addByAnonymRequest.PaymentType);

        addByAnonymRequest.MunfiqName = _service.FieldValidator.ValidateRequiredText255(addByAnonymRequest.MunfiqName);
        addByAnonymRequest.ManualNotes = _service.FieldValidator.ValidateOptionalText255(addByAnonymRequest.ManualNotes);


        var supportedPaymentTypes = new Payment.Interface.Model.PaymentType[]
        {
            Payment.Interface.Model.PaymentType.ManualBankTransfer,
        };

        if (!supportedPaymentTypes.Any(t => t == addByAnonymRequest.PaymentType)) throw new InputInvalidException(nameof(addByAnonymRequest.PaymentType));


        var manualPaymentTypes = new Payment.Interface.Model.PaymentType[]
        {
            Payment.Interface.Model.PaymentType.ManualBankTransfer,
        };

        if (manualPaymentTypes.Any(t => t == addByAnonymRequest.PaymentType))
        {
            addByAnonymRequest.ManualDateTime = _service.FieldValidator.ValidateRequiredPast(addByAnonymRequest.ManualDateTime);
        }


        await _data.Transaction.BeginAsync(_data.Infaq, _data.Payment);

        var infaq = new Entity.Infaq.Infaq
        {
            Id = _idGenerator.Infaq.InfaqId,
            Amount = addByAnonymRequest.Amount.Value,
            DateTime = utcNow,
            Status = PaymentStatus.New,
            PaymentType = addByAnonymRequest.PaymentType.Value.ToEntity(),
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
                    Id = _idGenerator.Infaq.InfaqFileId,
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
