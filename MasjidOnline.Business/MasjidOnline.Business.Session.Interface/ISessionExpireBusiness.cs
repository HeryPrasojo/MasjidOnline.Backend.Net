using System.Threading.Tasks;
using MasjidOnline.Data.Interface;

namespace MasjidOnline.Business.Session.Interface;

public interface ISessionExpireBusiness
{
    Task ExpireAsync(IData _data);
}
