using System.Threading.Tasks;
using MasjidOnline.Business.Accountancy;
using MasjidOnline.Business.Accountancy.Interface;
using MasjidOnline.Business.Authorization;
using MasjidOnline.Business.Captcha;
using MasjidOnline.Business.Captcha.Interface;
using MasjidOnline.Business.Infaq;
using MasjidOnline.Business.Infaq.Interface;
using MasjidOnline.Business.Interface;
using MasjidOnline.Business.Model.Options;
using MasjidOnline.Business.Payment;
using MasjidOnline.Business.Payment.Interface;
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
        IIdGenerator idGenerator,
        Service.Interface.IService service,
        ISessionBusiness sessionBusiness
    )
    {
        var authorizationBusiness = new AuthorizationBusiness();

        Accountancy = new AccountancyBusiness(authorizationBusiness, idGenerator, service);
        Infaq = new InfaqBusiness(optionsMonitor, authorizationBusiness, idGenerator, service);
        Payment = new PaymentBusiness(idGenerator);
        User = new UserBusiness(optionsMonitor, authorizationBusiness, idGenerator, sessionBusiness, service);
    }

    public IAccountancyBusiness Accountancy { get; }

    public ICaptchaBusiness Captcha { get; } = new CaptchaBusiness();

    public IInfaqBusiness Infaq { get; }

    public IPaymentBusiness Payment { get; }

    public IUserBusiness User { get; }

    public async Task InitializeAsync(IData _data)
    {
        await User.InitializeAsync(_data);
    }
}
