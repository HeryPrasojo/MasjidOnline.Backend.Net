using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Core;

namespace MasjidOnline.Data.Interface;

public interface ICoreEntityIdGenerator
{
    Task InitializeAsync(ICoreData coreData);
}
