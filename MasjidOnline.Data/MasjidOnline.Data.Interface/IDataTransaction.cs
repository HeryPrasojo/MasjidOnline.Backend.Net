using System.Threading.Tasks;

namespace MasjidOnline.Data.Interface;

public interface IDataTransaction
{
    Task BeginAsync(params IDataWithoutAudit[] datas);
    Task CommitAsync();
}
