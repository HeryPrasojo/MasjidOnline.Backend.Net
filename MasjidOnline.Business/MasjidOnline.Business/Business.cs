using System.Threading.Tasks;
using MasjidOnline.Business.Accountancy;
using MasjidOnline.Business.Accountancy.Interface;
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

// todo add sealed
public class Business(
    IOptionsMonitor<BusinessOptions> _optionsMonitor,
    Authorization.Interface.IAuthorizationBusiness _authorizationBusiness,
    IIdGenerator _idGenerator,
    ISessionBusiness _sessionBusiness,
    Service.Interface.IService _service
    ) : IBusiness
{
    public IAccountancyBusiness Accountancy { get; } = new AccountancyBusiness(_authorizationBusiness, _idGenerator, _service);

    public ICaptchaBusiness Captcha { get; } = new CaptchaBusiness();

    public IInfaqBusiness Infaq { get; } = new InfaqBusiness(_optionsMonitor, _authorizationBusiness, _idGenerator, _service);

    public IPaymentBusiness Payment { get; } = new PaymentBusiness(_idGenerator);

    public IUserBusiness User { get; } = new UserBusiness(_optionsMonitor, _authorizationBusiness, _idGenerator, _sessionBusiness, _service);

    public async Task InitializeAsync(IData _data)
    {
        await User.InitializeAsync(_data);
    }
}
