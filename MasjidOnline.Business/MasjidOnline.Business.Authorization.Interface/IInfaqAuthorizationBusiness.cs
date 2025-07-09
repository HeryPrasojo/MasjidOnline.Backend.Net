using MasjidOnline.Business.Authorization.Interface.Infaq;

namespace MasjidOnline.Business.Authorization.Interface;

public interface IInfaqAuthorizationBusiness
{
    public IExpireAuthorization Expire { get; }
    IInfaqAuthorization Infaq { get; }
    ISuccessAuthorization Success { get; }
    IVoidAuthorization Void { get; }
}
