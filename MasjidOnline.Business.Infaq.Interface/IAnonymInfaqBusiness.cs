using MasjidOnline.Api.Model.Infaq;

namespace MasjidOnline.Business.Infaq.Interface;

public interface IAnonymInfaqBusiness
{
    Task<AnonymInfaqResponse> DonateAsync(string? sessionId, AnonymInfaqRequest anonymInfaqRequest);
}
