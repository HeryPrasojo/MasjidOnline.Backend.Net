using System.Threading.Tasks;

namespace MasjidOnline.Data.Interface.IdGenerator;

public interface IAuthorizationIdGenerator
{
    //int InternaPermissionlId { get; }

    Task InitializeAsync(IData data);
}
