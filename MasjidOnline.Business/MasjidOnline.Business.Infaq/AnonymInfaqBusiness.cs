using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using MasjidOnline.Business.Infaq.Interface;
using MasjidOnline.Business.Infaq.Interface.Model;
using MasjidOnline.Business.Interface.Model;
using MasjidOnline.Business.Interface.Model.Responses;
using MasjidOnline.Business.Session.Interface;
using MasjidOnline.Data.Interface.Datas;
using MasjidOnline.Data.Interface.IdGenerator;
using MasjidOnline.Entity.Infaqs;
using MasjidOnline.Entity.Payments;
using MasjidOnline.Library.Exceptions;
using MasjidOnline.Library.Extentions;
using MasjidOnline.Service.FieldValidator.Interface;

namespace MasjidOnline.Business.Infaq;

public class AnonymInfaqBusiness(
    IFieldValidatorService _fieldValidatorService,
    IInfaqsIdGenerator _infaqsIdGenerator) : IAnonymInfaqBusiness
{
    public async Task<Response> InfaqAsync(
        ICaptchaData _captchaData,
        ISessionBusiness _sessionBusiness,
        IInfaqsData _infaqsData,
        AnonymInfaqRequest anonymInfaqRequest)
    {
        _fieldValidatorService.ValidateRequired(anonymInfaqRequest);
        _fieldValidatorService.ValidateRequiredPlus(anonymInfaqRequest.Amount);
        _fieldValidatorService.ValidateRequired(anonymInfaqRequest.PaymentType);
        _fieldValidatorService.ValidateRequiredPast(anonymInfaqRequest.ManualDateTime);

        anonymInfaqRequest.ManualNotes = _fieldValidatorService.ValidateRequiredText255(anonymInfaqRequest.ManualNotes);
        anonymInfaqRequest.MunfiqName = _fieldValidatorService.ValidateRequiredText255(anonymInfaqRequest.MunfiqName);


        if (_sessionBusiness.UserId == Constant.AnonymousUserId)
        {
            var captchaQuestions = await _captchaData.CaptchaQuestion.GetForAnonymInfaqAsync(_sessionBusiness.Id);

            if (!captchaQuestions.Any()) return new()
            {
                ResultCode = ResponseResult.CaptchaNeeded,
            };

            if (!captchaQuestions.Any(e => e.IsMatched)) return new()
            {
                ResultCode = ResponseResult.CaptchaNotPassed,
            };
        }
        ;


        var transaction = new Entity.Infaqs.Infaq
        {
            Id = _infaqsIdGenerator.TransactionId,
            Amount = anonymInfaqRequest.Amount,
            DateTime = DateTime.UtcNow,
            PaymentStatus = PaymentStatus.Pending,
            PaymentType = (PaymentType)anonymInfaqRequest.PaymentType,
            UserId = _sessionBusiness.UserId,
            MunfiqName = anonymInfaqRequest.MunfiqName,

            ManualDateTime = anonymInfaqRequest.ManualDateTime,
        };

        if (!anonymInfaqRequest.ManualNotes.IsNullOrEmptyOrWhiteSpace())
        {
            transaction.ManualNotes = anonymInfaqRequest.ManualNotes;
        }

        await _infaqsData.Transaction.AddAsync(transaction);


        if (anonymInfaqRequest.Files != default)
        {
            foreach (var file in anonymInfaqRequest.Files)
            {
                if (file.Length > 1048576) throw new InputInvalidException(nameof(anonymInfaqRequest.Files));

                var transactionFile = new InfaqFile
                {
                    Id = _infaqsIdGenerator.TransactionFileId,
                    InfaqId = transaction.Id,
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

                await _infaqsData.TransactionFile.AddAsync(transactionFile);
            }
        }


        await _infaqsData.SaveAsync();

        return new()
        {
            ResultCode = ResponseResult.Success,
        };
    }
}
