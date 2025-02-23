using System.Threading.Tasks;

namespace MasjidOnline.Data.Interface;

public interface IDataWithAudit : IData
{
    Task SaveWithTransactionAsync(int userId);
    Task SaveWithoutTransactionAsync(int userId);
}
