using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Databases;

namespace MasjidOnline.Data.Interface.IdGenerator;

public interface ICaptchaIdGenerator
{
    int CaptchaId { get; }

    Task InitializeAsync(ICaptchaDatabase captchaDatabase);
}
