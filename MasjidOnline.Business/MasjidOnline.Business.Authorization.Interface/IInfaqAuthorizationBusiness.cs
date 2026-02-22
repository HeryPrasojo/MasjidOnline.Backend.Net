using MasjidOnline.Business.Authorization.Interface.Infaq;

namespace MasjidOnline.Business.Authorization.Interface;

public interface IInfaqAuthorizationBusiness
{
    IInfaqAuthorization Infaq { get; }
}
