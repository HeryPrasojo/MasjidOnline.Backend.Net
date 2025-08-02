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
using MasjidOnline.Business.Session;
using MasjidOnline.Business.User;
using MasjidOnline.Business.User.Interface;
using MasjidOnline.Data.Interface;
using Microsoft.Extensions.Options;

namespace MasjidOnline.Business;

// hack low add sealed
public class Business : IBusiness
{
    public Business(
        IOptionsMonitor<BusinessOptions> _optionsMonitor,
        IIdGenerator _idGenerator,
        Service.Interface.IService _service
    )
    {
        var authorizationBusiness = new AuthorizationBusiness();
        var sessionBusiness = new SessionBusiness(_service, _idGenerator);

        Accountancy = new AccountancyBusiness(authorizationBusiness, _idGenerator, _service);
        Infaq = new InfaqBusiness(_optionsMonitor, authorizationBusiness, _idGenerator, _service);
        Payment = new PaymentBusiness(_idGenerator);
        User = new UserBusiness(_optionsMonitor, authorizationBusiness, _idGenerator, sessionBusiness, _service);
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
