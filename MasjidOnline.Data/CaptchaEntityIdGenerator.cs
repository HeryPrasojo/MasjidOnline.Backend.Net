using System.Threading;
using System.Threading.Tasks;
using MasjidOnline.Data.Interface;

namespace MasjidOnline.Data;

public class CaptchaEntityIdGenerator() : ICaptchaEntityIdGenerator
{
    private long _captchaAnswerId;
    private long _captchaQuestionId;

    public async Task InitializeAsync(ICaptchaData captchaData)
    {
        _captchaAnswerId = await captchaData.CaptchaAnswer.GetMaxIdAsync();
        _captchaQuestionId = await captchaData.CaptchaQuestion.GetMaxIdAsync();
    }

    public long CaptchaAnswerId => Interlocked.Increment(ref _captchaAnswerId);
    public long CaptchaQuestionId => Interlocked.Increment(ref _captchaQuestionId);


}
