using System.Threading;
using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Databases;
using MasjidOnline.Data.Interface.IdGenerator;

namespace MasjidOnline.Data.IdGenerator;

public class CaptchaIdGenerator : ICaptchaIdGenerator
{
    private int _captchaId;

    public async Task InitializeAsync(ICaptchaDatabase captchaDatabase)
    {
        _captchaId = await captchaDatabase.Captcha.GetMaxIdAsync();
    }

    public int CaptchaId => Interlocked.Increment(ref _captchaId);


}
