using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using MasjidOnline.Api.Model;
using MasjidOnline.Api.Model.Exceptions;
using MasjidOnline.Api.Model.Infaq;
using MasjidOnline.Business.Infaq.Interface;
using MasjidOnline.Data.Interface;
using MasjidOnline.Data.Interface.Captcha;
using MasjidOnline.Data.Interface.Transactions;
using MasjidOnline.Entity.Payments;
using MasjidOnline.Entity.Transactions;
using MasjidOnline.Library.Extentions;

namespace MasjidOnline.Business.Infaq;

public class AnonymInfaqBusiness(
    ITransactionData _transactionData,
    ITransactionIdGenerator _transactionIdGenerator,
    ICaptchaData _captchaData) : IAnonymInfaqBusiness
{
    public async Task<AnonymInfaqResponse> InfaqAsync(byte[]? sessionId, AnonymInfaqRequest anonymInfaqRequest)
    {
        if (sessionId == default) throw new InputInvalidException(nameof(sessionId));

        if (anonymInfaqRequest == default) throw new InputInvalidException(nameof(anonymInfaqRequest));

        if (anonymInfaqRequest.Amount == default) throw new InputInvalidException(nameof(anonymInfaqRequest.Amount));

        if (anonymInfaqRequest.MunfiqName.IsNullOrEmptyOrWhiteSpace()) throw new InputInvalidException(nameof(anonymInfaqRequest.MunfiqName));

        if (anonymInfaqRequest.PaymentType == default) throw new InputInvalidException(nameof(anonymInfaqRequest.PaymentType));

        // todo check session logged in


        var captchaQuestionIds = await _captchaData.CaptchaQuestion.GetIdsBySessionIdAsync(sessionId);

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
            Amount = anonymInfaqRequest.Amount,
            DateTime = DateTime.UtcNow,
            Id = _transactionIdGenerator.TransactionId,
            PaymentStatus = PaymentStatus.Pending,
            PaymentType = (PaymentType)anonymInfaqRequest.PaymentType,
            Type = TransactionType.Infaq,
            UserId = default,
            MunfiqName = anonymInfaqRequest.MunfiqName,
            UserType = Entity.User.UserType.Anonymous,
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
            }
        }

        //throw new NotImplementedException();

        // undone
    }
}
