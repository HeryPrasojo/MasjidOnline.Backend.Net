using System.Threading.Tasks;
using MasjidOnline.Business.Accountancy.Interface;
using MasjidOnline.Business.Captcha.Interface;
using MasjidOnline.Business.Infaq.Interface;
using MasjidOnline.Business.Payment.Interface;
using MasjidOnline.Business.User.Interface;
using MasjidOnline.Data.Interface;

namespace MasjidOnline.Business.Interface;

public interface IBusiness
{
    ICaptchaBusiness Captcha { get; }
    IInfaqBusiness Infaq { get; }
    IUserBusiness User { get; }
    IAccountancyBusiness Accountancy { get; }
    IPaymentBusiness Payment { get; }

    Task InitializeAsync(IData _data);
}
