using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using MasjidOnline.Data.Interface;

namespace MasjidOnline.Business.Session.Interface;

public interface ISessionBusiness
{
    Task ChangeAndSaveAsync(Interface.Session session, IData _data, int userId);
    Task ChangeAsync(Interface.Session session, IData _data, int userId);
    string GetDigestBase64(Session session);
    Task StartAsync(Interface.Session session, IData _data, string? idBase64, [CallerArgumentExpression(nameof(idBase64))] string? idBase64Expression = null);
}
