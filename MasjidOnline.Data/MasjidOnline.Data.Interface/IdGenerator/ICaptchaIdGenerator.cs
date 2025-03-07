using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Datas;

namespace MasjidOnline.Data.Interface.IdGenerator;

public interface ICaptchaIdGenerator
{
    int CaptchaId { get; }

    Task InitializeAsync(ICaptchaData captchaData);
}
