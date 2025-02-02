using MasjidOnline.Business.Infaq.Interface.Model;
using MasjidOnline.Data.Interface.Datas;

namespace MasjidOnline.Business.Infaq.Interface;

public interface IAnonymInfaqBusiness
{
    Task<AnonymInfaqResponse> InfaqAsync(ICaptchaData _captchaData, ITransactionsData _transactionData, byte[]? sessionId, AnonymInfaqRequest anonymInfaqRequest);
}
