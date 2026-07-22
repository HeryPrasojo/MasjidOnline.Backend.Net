using System.Threading.Tasks;
using MasjidOnline.Business.Model.Session;
using MasjidOnline.Data.Interface;

namespace MasjidOnline.Business.Authorization.Interface.Donation;

public interface IDonationAuthorization
{
    Task AuthorizeRequestFailAync(Session session, IData _data);
}


