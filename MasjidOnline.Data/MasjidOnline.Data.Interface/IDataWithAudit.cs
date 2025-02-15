using System.Threading.Tasks;

namespace MasjidOnline.Data.Interface;

public interface IDataWithAudit : IData
{
    Task SaveAsync(int userId);
}
