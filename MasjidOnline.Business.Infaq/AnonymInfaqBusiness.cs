using System.Linq;
using System.Threading.Tasks;
using MasjidOnline.Api.Model;
using MasjidOnline.Api.Model.Exception;
using MasjidOnline.Api.Model.Infaq;
using MasjidOnline.Business.Infaq.Interface;
using MasjidOnline.Data.Interface.Captcha;
using MasjidOnline.Data.Interface.Transaction;
using MasjidOnline.Entity.Transaction;

namespace MasjidOnline.Business.Infaq;

public class AnonymInfaqBusiness(
    ITransactionData _transactionData,
    ICaptchaData _captchaData) : IAnonymInfaqBusiness
{
    public async Task<AnonymInfaqResponse> InfaqAsync(byte[] sessionId, AnonymInfaqRequest anonymInfaqRequest)
    {
        if (sessionId == default) throw new InputInvalidException(nameof(sessionId));


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
            Amount = ,
            DateTime =,
            Files =,
            Id =,
            ManualBankTransferSourceBankId =,
            PaymentStatus =,
            PaymentType =,
            Type =,
            UserId =,
            UserName =,
            UserType =,
        };

        await _transactionData.Transaction.AddAsync(transaction);
        // undone
    }
}
