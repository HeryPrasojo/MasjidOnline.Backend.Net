using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using MasjidOnline.Data.Interface;

namespace MasjidOnline.Business.Session.Interface;

public interface ISessionAuthenticationBusiness
{
    Task AuthenticateAsync(Model.Session session, IData _data, string? codeBase64, [CallerArgumentExpression(nameof(codeBase64))] string? idBase64Expression = null);
}
