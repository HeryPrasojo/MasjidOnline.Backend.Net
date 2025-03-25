using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Databases;

namespace MasjidOnline.Data.Interface.IdGenerator;

public interface IPersonIdGenerator
{
    Task InitializeAsync(IPersonDatabase personDatabase);
}
