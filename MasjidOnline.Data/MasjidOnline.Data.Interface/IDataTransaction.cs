using System.Threading.Tasks;

namespace MasjidOnline.Data.Interface;

public interface IDataTransaction
{
    Task BeginAsync(params IDatabase[] datas);
    Task CommitAsync();
    Task RollbackAsync();
}
