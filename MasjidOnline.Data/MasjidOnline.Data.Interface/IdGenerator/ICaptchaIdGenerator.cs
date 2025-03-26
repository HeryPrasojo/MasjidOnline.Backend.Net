using System.Threading.Tasks;

namespace MasjidOnline.Data.Interface.IdGenerator;

public interface ICaptchaIdGenerator
{
    int CaptchaId { get; }

    Task InitializeAsync(IData data);
}
