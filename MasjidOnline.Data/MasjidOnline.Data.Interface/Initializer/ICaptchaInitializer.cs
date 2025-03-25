using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Databases;

namespace MasjidOnline.Data.Interface.Initializer;

public interface ICaptchaInitializer
{
    Task InitializeDatabaseAsync(ICaptchaDatabase captchaDatabase);
}
