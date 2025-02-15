using System.Threading.Tasks;

namespace MasjidOnline.Data.Interface;

public interface IDefinition
{
    Task<bool> CheckTableExistsAsync(string name);
}
