using System.Threading.Tasks;
using MasjidOnline.Business.Accountancy;
using MasjidOnline.Business.Accountancy.Interface;
using MasjidOnline.Business.Authorization;
using MasjidOnline.Business.Authorization.Interface;
using MasjidOnline.Business.Event;
using MasjidOnline.Business.Event.Interface;
using MasjidOnline.Business.Infaq;
using MasjidOnline.Business.Infaq.Interface;
using MasjidOnline.Business.Interface;
using MasjidOnline.Business.Model.Options;
using MasjidOnline.Business.Payment;
using MasjidOnline.Business.Payment.Interface;
using MasjidOnline.Business.Session;
using MasjidOnline.Business.Session.Interface;
using MasjidOnline.Business.User;
using MasjidOnline.Business.User.Interface;
using MasjidOnline.Data.Interface;
using Microsoft.Extensions.Options;

namespace MasjidOnline.Business;

// hack low add sealed
public class Business : IBusiness
{
    public Business(
        IOptionsMonitor<BusinessOptions> optionsMonitor,
        Service.Interface.IService service
    )
    {
        Authorization = new AuthorizationBusiness();

        Accountancy = new AccountancyBusiness(Authorization, service);
        Event = new EventBusiness();
        Infaq = new InfaqBusiness(optionsMonitor, Authorization, service);
        Payment = new PaymentBusiness(service);
        Session = new SessionBusiness(service);
        User = new UserBusiness(optionsMonitor, Authorization, service);
    }

    public IAccountancyBusiness Accountancy { get; }

    public IAuthorizationBusiness Authorization { get; }

    public IEventBusiness Event { get; }

    public IInfaqBusiness Infaq { get; }

    public IPaymentBusiness Payment { get; }

    public ISessionBusiness Session { get; }

    public IUserBusiness User { get; }

    public async Task InitializeAsync(IData _data)
    {
        await User.InitializeAsync(_data);
    }
}
