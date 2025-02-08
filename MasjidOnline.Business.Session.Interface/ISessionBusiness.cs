using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace MasjidOnline.Business.Session.Interface;

public interface ISessionBusiness
{
    bool IsIdNew { get; }
    string IdBase64 { get; }
    int UserId { get; }

    Task ChangeAsync(int userId);
    void Initialize();
    Task StartAsync(string? idBase64, [CallerArgumentExpression("idBase64")] string? idBase64Expression = null);
}
