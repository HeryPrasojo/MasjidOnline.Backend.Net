using System.Threading;
using System.Threading.Tasks;
using MasjidOnline.Data.Interface;
using MasjidOnline.Data.Interface.IdGenerator;

namespace MasjidOnline.Data.IdGenerators;

public class CaptchaIdGenerator : ICaptchaIdGenerator
{
    private int _captchaId;

    public async Task InitializeAsync(IData data)
    {
        _captchaId = await data.Captcha.Captcha.GetMaxIdAsync();
    }

    public int CaptchaId => Interlocked.Increment(ref _captchaId);


}
