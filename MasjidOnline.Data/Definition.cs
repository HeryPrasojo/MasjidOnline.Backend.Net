using System.Threading.Tasks;
using MasjidOnline.Data.Interface;
namespace MasjidOnline.Data;

public abstract class Definition : IDefinition
{
    public abstract Task<bool> CheckTableExistsAsync(string name);
}
