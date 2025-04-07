using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using MasjidOnline.Data.Interface;

namespace MasjidOnline.Business.Session.Interface;

public interface ISessionBusiness
{
    int UserId { get; }
    int Id { get; }
    bool IsUserAnonymous { get; }

    Task ChangeAndSaveAsync(IData _data, int userId);
    Task ChangeAsync(IData _data, int userId);
    string GetDigestBase64(Session session);
    Task StartAsync(IData _data, string? idBase64, [CallerArgumentExpression(nameof(idBase64))] string? idBase64Expression = null);
}
