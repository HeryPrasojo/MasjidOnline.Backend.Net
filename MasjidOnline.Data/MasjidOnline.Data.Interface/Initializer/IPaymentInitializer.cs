using System.Threading.Tasks;

namespace MasjidOnline.Data.Interface.Initializer;

public interface IPaymentInitializer
{
    Task InitializeDatabaseAsync(IData data);
}
