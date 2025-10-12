using System.Threading.Tasks;
using MasjidOnline.Business.Accountancy.Interface;
using MasjidOnline.Business.Infaq.Interface;
using MasjidOnline.Business.Payment.Interface;
using MasjidOnline.Business.Session.Interface;
using MasjidOnline.Business.User.Interface;
using MasjidOnline.Data.Interface;

namespace MasjidOnline.Business.Interface;

public interface IBusiness
{
    IInfaqBusiness Infaq { get; }
    IUserBusiness User { get; }
    IAccountancyBusiness Accountancy { get; }
    IPaymentBusiness Payment { get; }
    ISessionBusiness Session { get; }

    Task InitializeAsync(IData _data);
}
