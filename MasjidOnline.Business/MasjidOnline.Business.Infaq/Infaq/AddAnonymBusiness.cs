using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using MasjidOnline.Business.Infaq.Infaq.Mapper;
using MasjidOnline.Business.Infaq.Interface.Infaq;
using MasjidOnline.Business.Infaq.Interface.Model.Infaq;
using MasjidOnline.Business.Interface.Model.Responses;
using MasjidOnline.Business.Model;
using MasjidOnline.Business.Session.Interface;
using MasjidOnline.Data.Interface;
using MasjidOnline.Data.Interface.IdGenerator;
using MasjidOnline.Entity.Infaq;
using MasjidOnline.Library.Exceptions;
using MasjidOnline.Service.FieldValidator.Interface;

namespace MasjidOnline.Business.Infaq.Infaq;

public class AddAnonymBusiness(
    IFieldValidatorService _fieldValidatorService,
    IInfaqIdGenerator _infaqIdGenerator) : IAddAnonymBusiness
{
    public async Task<Response> AddAsync(
        IData _data,
        ISessionBusiness _sessionBusiness,
        AddByAnonymRequest? addByAnonymRequest)
    {
        if (_sessionBusiness.UserId == Constant.UserId.Anonymous)
        {
            var captchas = await _data.Captcha.Captcha.GetForInfaqAddByAnonymAsync(_sessionBusiness.Id);

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
        _fieldValidatorService.ValidateRequiredPlus(addByAnonymRequest!.Amount);
        _fieldValidatorService.ValidateRequired(addByAnonymRequest.PaymentType);
        _fieldValidatorService.ValidateRequiredPast(addByAnonymRequest.ManualDateTime);

        addByAnonymRequest.MunfiqName = _fieldValidatorService.ValidateRequiredText255(addByAnonymRequest.MunfiqName);
        addByAnonymRequest.ManualNotes = _fieldValidatorService.ValidateOptionalText255(addByAnonymRequest.ManualNotes);


        var paymentTypes = new Interface.Model.Payment.PaymentType[]
        {
            Interface.Model.Payment.PaymentType.ManualBankTransfer
        };

        if (!paymentTypes.Any(t => t == addByAnonymRequest.PaymentType)) throw new InputInvalidException(nameof(addByAnonymRequest.PaymentType));


        var infaq = new Entity.Infaq.Infaq
        {
            Id = _infaqIdGenerator.InfaqId,
            Amount = addByAnonymRequest.Amount!.Value,
            DateTime = DateTime.UtcNow,
            PaymentStatus = PaymentStatus.New,
            PaymentType = addByAnonymRequest.PaymentType!.Value.ToEntity(),
            UserId = _sessionBusiness.UserId,
            MunfiqName = addByAnonymRequest.MunfiqName,
        };

        await _data.Infaq.Infaq.AddAsync(infaq);


        if (infaq.PaymentType == PaymentType.ManualBankTransfer)
        {
            var infaqManual = new InfaqManual
            {
                InfaqId = infaq.Id,
                DateTime = addByAnonymRequest.ManualDateTime!.Value,
                Notes = addByAnonymRequest.ManualNotes,
            };

            await _data.Infaq.InfaqManual.AddAsync(infaqManual);
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

                await _data.Infaq.InfaqFile.AddAsync(infaqFile);
            }
        }


        await _data.Infaq.SaveAsync();

        return new()
        {
            ResultCode = ResponseResultCode.Success,
        };
    }
}
