using System.Threading.Tasks;
using MasjidOnline.Business.Accountancy.Interface;
using MasjidOnline.Business.Authorization.Interface;
using MasjidOnline.Business.Event.Interface;
using MasjidOnline.Business.Infaq.Interface;
using MasjidOnline.Business.Payment.Interface;
using MasjidOnline.Business.Session.Interface;
using MasjidOnline.Business.User.Interface;
using MasjidOnline.Data.Interface;

namespace MasjidOnline.Business.Interface;

public interface IBusiness
{
    IAccountancyBusiness Accountancy { get; }
    IAuthorizationBusiness Authorization { get; }
    IEventBusiness Event { get; }
    IInfaqBusiness Infaq { get; }
    IPaymentBusiness Payment { get; }
    ISessionBusiness Session { get; }
    IUserBusiness User { get; }

    Task InitializeAsync(IData _data);
}
