using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Databases;

namespace MasjidOnline.Data.Interface.Initializer;

public interface IInfaqInitializer
{
    Task InitializeDatabaseAsync(IInfaqDatabase transactionData);
}
