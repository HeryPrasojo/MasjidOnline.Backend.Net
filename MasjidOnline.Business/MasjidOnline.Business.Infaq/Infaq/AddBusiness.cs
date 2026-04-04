using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using MasjidOnline.Business.Authorization.Interface;
using MasjidOnline.Business.Infaq.Interface.Infaq;
using MasjidOnline.Business.Model.Infaq.Infaq;
using MasjidOnline.Business.Model.Options;
using MasjidOnline.Business.Model.Payment.Payment;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Data.Interface;
using MasjidOnline.Entity.Infaq;
using MasjidOnline.Library.Exceptions;
using MasjidOnline.Library.Extensions;
using MasjidOnline.Service.Interface;
using Microsoft.Extensions.Options;

namespace MasjidOnline.Business.Infaq.Infaq;

public class AddBusiness(
    IAuthorizationBusiness _authorizationBusiness,
    IService _service,
    IOptionsMonitor<BusinessOptions> _optionsMonitor) : IAddBusiness
{
    public async Task<Response> AddAsync(IData _data, Model.Session.Session session, AddRequest? addRequest)
    {
        addRequest = _service.FieldValidator.ValidateRequired(addRequest);
        addRequest.CaptchaToken = _service.FieldValidator.ValidateRequired(addRequest.CaptchaToken);
        addRequest.Amount = _service.FieldValidator.ValidateRequiredPlus(addRequest.Amount);
        addRequest.PaymentType = _service.FieldValidator.ValidateRequiredEnum(addRequest.PaymentType);
        addRequest.MunfiqName = _service.FieldValidator.ValidateRequiredTextDb255(addRequest.MunfiqName);
        addRequest.ManualNotes = _service.FieldValidator.ValidateOptionalTextDb255(addRequest.ManualNotes);


        switch (addRequest.PaymentType)
        {
            case PaymentType.ManualBankTransfer:
            {
                addRequest.ManualDateTime = _service.FieldValidator.ValidateRequiredPast(addRequest.ManualDateTime);

                break;
            }
        }


        var isCaptchaVerified = await _service.Captcha.VerifyInfaqAsync(addRequest.CaptchaToken);

        if (!isCaptchaVerified) throw new InputMismatchException(nameof(addRequest.CaptchaToken));


        await _data.Transaction.BeginAsync(_data.Payment, _data.Infaq);

        var utcNow = DateTime.UtcNow;

        var payment = new Entity.Payment.Payment
        {
            DateTime = utcNow,
            Id = _data.IdGenerator.Payment.PaymentId,
            PaymentType = Mapper.Mapper.Payment.PaymentType[addRequest.PaymentType.Value],
            Status = Entity.Payment.PaymentStatus.New,
        };

        if (addRequest.PaymentType == PaymentType.ManualBankTransfer)
        {
            if (!addRequest.ManualNotes.IsNullOrEmptyOrWhiteSpace()) payment.ManualNotes = addRequest.ManualNotes;
        }

        await _data.Payment.Payment.AddAsync(payment);


        var infaq = new Entity.Infaq.Infaq
        {
            Id = _data.IdGenerator.Infaq.InfaqId,
            Amount = addRequest.Amount.Value,
            DateTime = utcNow,
            MunfiqName = addRequest.MunfiqName,
            PaymentId = payment.Id,
            PaymentType = Mapper.Mapper.Payment.PaymentType[addRequest.PaymentType.Value],
            ReceiverType = ReceiverType.MasjidOnline,
            Status = Entity.Infaq.InfaqStatus.New,
            UserId = session.UserId,
        };

        await _data.Infaq.Infaq.AddAsync(infaq);


        var temporaryFiles = new List<(string path, string temporaryPath)>();

        if (addRequest.PaymentType == PaymentType.ManualBankTransfer)
        {
            if (addRequest.Files != default)
            {
                foreach (var file in addRequest.Files)
                {
                    var paymentFile = new Entity.Payment.PaymentFile
                    {
                        Id = _data.IdGenerator.Payment.PaymentFileId,
                        PaymentId = payment.Id,
                    };

                    var fileName = paymentFile.Id;

                    var path = _optionsMonitor.CurrentValue.Directory.Infaq + fileName;
                    var temporaryPath = _optionsMonitor.CurrentValue.Directory.Infaq + '_' + fileName;


                    await _service.File.CreateAsync(file, temporaryPath);

                    await _data.Payment.PaymentFile.AddAsync(paymentFile);

                    temporaryFiles.Add((path, temporaryPath));
                }
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
