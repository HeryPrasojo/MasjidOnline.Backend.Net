using System.Threading;
using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Datas;
using MasjidOnline.Data.Interface.IdGenerator;

namespace MasjidOnline.Data.IdGenerator;

public class CaptchaIdGenerator : ICaptchaIdGenerator
{
    private int _captchaId;

    public async Task InitializeAsync(ICaptchaData captchaData)
    {
        _captchaId = await captchaData.Captcha.GetMaxIdAsync();
    }

    public int CaptchaId => Interlocked.Increment(ref _captchaId);


}
