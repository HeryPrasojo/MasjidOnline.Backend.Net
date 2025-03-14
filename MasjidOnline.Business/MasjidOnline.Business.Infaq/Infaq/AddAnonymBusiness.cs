using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using MasjidOnline.Business.Infaq.Interface.Infaq;
using MasjidOnline.Business.Infaq.Interface.Model.Infaq;
using MasjidOnline.Business.Interface.Model;
using MasjidOnline.Business.Interface.Model.Responses;
using MasjidOnline.Business.Session.Interface;
using MasjidOnline.Data.Interface.Datas;
using MasjidOnline.Data.Interface.IdGenerator;
using MasjidOnline.Entity.Infaq;
using MasjidOnline.Library.Exceptions;
using MasjidOnline.Library.Extensions;
using MasjidOnline.Service.FieldValidator.Interface;

namespace MasjidOnline.Business.Infaq.Infaq;

public class AddAnonymBusiness(
    IFieldValidatorService _fieldValidatorService,
    IInfaqIdGenerator _infaqIdGenerator) : IAddAnonymBusiness
{
    public async Task<Response> AddAsync(
        ICaptchaData _captchaData,
        ISessionBusiness _sessionBusiness,
        IInfaqData _infaqData,
        AddByAnonymRequest addByAnonymRequest)
    {
        if (_sessionBusiness.UserId == Constant.AnonymousUserId)
        {
            var captchas = await _captchaData.Captcha.GetForInfaqAddByAnonymAsync(_sessionBusiness.Id);

            if (!captchas.Any()) return new()
            {
                ResultCode = ResponseResultCode.CaptchaNeed,
            };

            if (!captchas.Any(e => e.IsMatched == true)) return new()
            {
                ResultCode = ResponseResultCode.CaptchaUnpass,
            };
        }


        _fieldValidatorService.ValidateRequired(addByAnonymRequest);
        _fieldValidatorService.ValidateRequiredPlus(addByAnonymRequest.Amount);
        _fieldValidatorService.ValidateRequired(addByAnonymRequest.PaymentType);
        _fieldValidatorService.ValidateRequiredPast(addByAnonymRequest.ManualDateTime);

        addByAnonymRequest.ManualNotes = _fieldValidatorService.ValidateRequiredText255(addByAnonymRequest.ManualNotes);
        addByAnonymRequest.MunfiqName = _fieldValidatorService.ValidateRequiredText255(addByAnonymRequest.MunfiqName);


        var paymentTypes = new Interface.Model.Payment.PaymentType[]
        {
            Interface.Model.Payment.PaymentType.ManualBankTransfer
        };

        if (!paymentTypes.Any(t => t == addByAnonymRequest.PaymentType)) throw new InputInvalidException(nameof(addByAnonymRequest.PaymentType));


        var infaq = new Entity.Infaq.Infaq
        {
            Id = _infaqIdGenerator.InfaqId,
            Amount = addByAnonymRequest.Amount,
            DateTime = DateTime.UtcNow,
            PaymentStatus = PaymentStatus.New,
            PaymentType = (PaymentType)addByAnonymRequest.PaymentType,
            UserId = _sessionBusiness.UserId,
            MunfiqName = addByAnonymRequest.MunfiqName,
        };

        await _infaqData.Infaq.AddAsync(infaq);


        if (infaq.PaymentType == PaymentType.ManualBankTransfer)
        {
            var infaqManual = new InfaqManual
            {
                InfaqId = infaq.Id,
                ManualDateTime = addByAnonymRequest.ManualDateTime,
            };

            if (!addByAnonymRequest.ManualNotes.IsNullOrEmptyOrWhiteSpace())
                infaqManual.ManualNotes = addByAnonymRequest.ManualNotes;

            await _infaqData.InfaqManual.AddAsync(infaqManual);
        }


        if (addByAnonymRequest.Files != default)
        {
            foreach (var file in addByAnonymRequest.Files)
            {
                if (file.Length > 1048576) throw new InputInvalidException(nameof(addByAnonymRequest.Files));

                var infaqFile = new InfaqFile
                {
                    Id = _infaqIdGenerator.InfaqFileId,
                    InfaqId = infaq.Id,
                };

                var fileStreamOptions = new FileStreamOptions
                {
                    Access = FileAccess.Write,
                    Mode = FileMode.CreateNew,
                    Options = FileOptions.WriteThrough,
                    PreallocationSize = file.Length,
                    Share = FileShare.None,
                };

                using var fileStream = new FileStream("..\\..\\upload\\transaction\\", fileStreamOptions);

                await file.CopyToAsync(fileStream);

                await fileStream.FlushAsync();

                fileStream.Close();

                await _infaqData.InfaqFile.AddAsync(infaqFile);
            }
        }


        await _infaqData.SaveAsync();

        return new()
        {
            ResultCode = ResponseResultCode.Success,
        };
    }
}
