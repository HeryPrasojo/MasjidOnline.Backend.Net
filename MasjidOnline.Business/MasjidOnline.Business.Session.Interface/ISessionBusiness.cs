using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using MasjidOnline.Data.Interface;

namespace MasjidOnline.Business.Session.Interface;

public interface ISessionBusiness
{
    Task<string?> StartAsync(Model.Session session, IData _data, string? idBase64, string? cultureName, [CallerArgumentExpression(nameof(idBase64))] string? idBase64Expression = null);
}
