using System;
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

        if (anonymInfaqRequest.Name == default) throw new InputInvalidException(nameof(anonymInfaqRequest.Name));

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
            UserId =,
            UserName =,
            UserType =,
        };

        if (anonymInfaqRequest.ManualBankTransferSourceBankId != default)
        {
            transaction.ManualBankTransferSourceBankId = anonymInfaqRequest.ManualBankTransferSourceBankId;
        }
        await _transactionData.Transaction.AddAsync(transaction);
        // undone
    }
}
