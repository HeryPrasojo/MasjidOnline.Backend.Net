using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Databases;

namespace MasjidOnline.Data.Interface.Initializer;

public interface IAuditInitializer
{
    Task InitializeDatabaseAsync(IAuditDatabase auditDatabase);
}
