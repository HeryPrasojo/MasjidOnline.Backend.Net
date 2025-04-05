using System.Threading.Tasks;
using MasjidOnline.Entity.Captcha;

namespace MasjidOnline.Data.Interface.Repository.Captcha;

public interface IPassRepository
{
    Task AddAndSaveAsync(Pass pass);
    Task<bool> AnyAsync(int sessionId);
}
