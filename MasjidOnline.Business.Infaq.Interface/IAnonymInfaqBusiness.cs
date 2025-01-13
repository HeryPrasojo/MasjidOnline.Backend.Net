using MasjidOnline.Api.Model.Infaq;

namespace MasjidOnline.Business.Infaq.Interface;

public interface IAnonymInfaqBusiness
{
    Task<AnonymInfaqResponse> InfaqAsync(byte[] sessionId, AnonymInfaqRequest anonymInfaqRequest);
}
