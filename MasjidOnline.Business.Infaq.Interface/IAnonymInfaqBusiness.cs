using MasjidOnline.Business.Infaq.Interface.Model;

namespace MasjidOnline.Business.Infaq.Interface;

public interface IAnonymInfaqBusiness
{
    Task<AnonymInfaqResponse> InfaqAsync(byte[]? sessionId, AnonymInfaqRequest anonymInfaqRequest);
}
