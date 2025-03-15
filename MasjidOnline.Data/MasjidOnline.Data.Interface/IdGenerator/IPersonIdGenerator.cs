using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Datas;

namespace MasjidOnline.Data.Interface.IdGenerator;

public interface IPersonIdGenerator
{
    Task InitializeAsync(IPersonData personData);
}
