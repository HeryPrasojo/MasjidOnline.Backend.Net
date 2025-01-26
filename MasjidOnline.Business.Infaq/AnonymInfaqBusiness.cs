using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using MasjidOnline.Business.Infaq.Interface;
using MasjidOnline.Business.Infaq.Interface.Model;
using MasjidOnline.Business.Interface.Model;
using MasjidOnline.Data.Interface.Datas;
using MasjidOnline.Data.Interface.IdGenerator;
using MasjidOnline.Entity.Payments;
using MasjidOnline.Entity.Transactions;
using MasjidOnline.Library.Exceptions;
using MasjidOnline.Library.Extentions;
using MasjidOnline.Service.FieldValidator.Interface;

namespace MasjidOnline.Business.Infaq;

public class AnonymInfaqBusiness(
    ICaptchaData _captchaData,
    IFieldValidatorService _fieldValidatorService,
    ITransactionData _transactionData,
    ITransactionIdGenerator _transactionIdGenerator) : IAnonymInfaqBusiness
{
    // todo user 
    public async Task<AnonymInfaqResponse> InfaqAsync(byte[]? sessionId, AnonymInfaqRequest anonymInfaqRequest)
    {
        _fieldValidatorService.ValidateRequired(sessionId);
        _fieldValidatorService.ValidateRequired(anonymInfaqRequest);
        _fieldValidatorService.ValidateRequired(anonymInfaqRequest.Amount);
        _fieldValidatorService.ValidateRequired(anonymInfaqRequest.PaymentType);
        _fieldValidatorService.ValidateRequiredDateTimePast(anonymInfaqRequest.ManualBankTransferDateTime);

        anonymInfaqRequest.ManualBankTransferNotes = _fieldValidatorService.ValidateRequiredTextShort(anonymInfaqRequest.ManualBankTransferNotes);
        anonymInfaqRequest.MunfiqName = _fieldValidatorService.ValidateRequiredTextShort(anonymInfaqRequest.MunfiqName);


        // todo check session logged in


        var captchaQuestionIds = await _captchaData.CaptchaQuestion.GetIdsBySessionIdAsync(sessionId!);

        if (!captchaQuestionIds.Any()) return new()
        {
            ResultCode = ResponseResult.CaptchaNeeded,
        };


        var isAnyMatch = await _captchaData.CaptchaAnswer.GetAnyIsMatchByCaptchaQuestionIdsAsync(captchaQuestionIds);

        if (!isAnyMatch) return new()
        {
            ResultCode = ResponseResult.CaptchaNotPassed,
        };


        var transaction = new Transaction
        {
            Id = _transactionIdGenerator.TransactionId,
            Amount = anonymInfaqRequest.Amount,
            CreateDateTime = DateTime.UtcNow,
            PaymentStatus = PaymentStatus.Pending,
            PaymentType = (PaymentType)anonymInfaqRequest.PaymentType,
            Type = TransactionType.Infaq,
            UserId = default,
            MunfiqName = anonymInfaqRequest.MunfiqName,

            ManualBankTransferDateTime = anonymInfaqRequest.ManualBankTransferDateTime,
        };

        if (!anonymInfaqRequest.ManualBankTransferNotes.IsNullOrEmptyOrWhiteSpace())
        {
            transaction.ManualBankTransferNotes = anonymInfaqRequest.ManualBankTransferNotes;
        }

        await _transactionData.Transaction.AddAsync(transaction);


        if (anonymInfaqRequest.Files != default)
        {
            foreach (var file in anonymInfaqRequest.Files)
            {
                if (file.Length > 1048576) throw new InputInvalidException(nameof(anonymInfaqRequest.Files));

                var transactionFile = new TransactionFile
                {
                    Id = _transactionIdGenerator.TransactionFileId,
                    TransactionId = transaction.Id,
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

                await _transactionData.TransactionFile.AddAsync(transactionFile);
            }
        }


        await _transactionData.SaveAsync();

        return new()
        {
            ResultCode = ResponseResult.Success,
        };
    }
}
