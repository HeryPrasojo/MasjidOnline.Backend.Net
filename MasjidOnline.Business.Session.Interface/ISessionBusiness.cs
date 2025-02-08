using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace MasjidOnline.Business.Session.Interface;

public interface ISessionBusiness
{
    bool IsDigestNew { get; }
    string DigestBase64 { get; }
    int UserId { get; }
    int Id { get; }

    Task ChangeAsync(int userId);
    Task StartAsync(string? idBase64, [CallerArgumentExpression("idBase64")] string? idBase64Expression = null);
}
