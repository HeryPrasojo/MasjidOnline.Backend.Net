using MasjidOnline.Business.Authorization.Infaq;
using MasjidOnline.Business.Authorization.Interface;
using MasjidOnline.Business.Authorization.Interface.Infaq;

namespace MasjidOnline.Business.Authorization;

internal class InfaqAuthorizationBusiness : IInfaqAuthorizationBusiness
{
    public IInfaqAuthorization Infaq { get; } = new InfaqAuthorization();
}
