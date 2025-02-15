using System.Threading.Tasks;

namespace MasjidOnline.Data.Interface;

public interface IDataWithoutAudit
{
    Task BeginTransactionAsync();
    Task CommitTransactionAsync();
    Task SaveAsync();
}
