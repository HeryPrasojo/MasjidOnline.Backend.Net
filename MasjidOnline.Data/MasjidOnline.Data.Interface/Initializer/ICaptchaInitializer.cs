using System.Threading.Tasks;

namespace MasjidOnline.Data.Interface.Initializer;

public interface ICaptchaInitializer
{
    Task InitializeDatabaseAsync(IData data);
}
