using MasjidOnline.Business.Authorization.Infaq;
using MasjidOnline.Business.Authorization.Interface;
using MasjidOnline.Business.Authorization.Interface.Infaq;

namespace MasjidOnline.Business.Authorization;

internal class InfaqAuthorizationBusiness : IInfaqAuthorizationBusiness
{
    public IExpireAuthorization Expire { get; } = new ExpireAuthorization();
    public IInfaqAuthorization Infaq { get; } = new InfaqAuthorization();
    public ISuccessAuthorization Success { get; } = new SuccessAuthorization();
    public IVoidAuthorization Void { get; } = new VoidAuthorization();
}
