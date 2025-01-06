using System.Threading;
using System.Threading.Tasks;
using MasjidOnline.Data.Interface;
using MasjidOnline.Data.Interface.Core;

namespace MasjidOnline.Data;

public class CoreEntityIdGenerator() : ICoreEntityIdGenerator
{
    private long _captchaAnswerId;
    private long _captchaQuestionId;

    public async Task InitializeAsync(ICoreData coreData)
    {
        _captchaAnswerId = await coreData.CaptchaAnswer.GetMaxIdAsync();
        _captchaQuestionId = await coreData.CaptchaQuestion.GetMaxIdAsync();
    }

    public long CaptchaAnswerId => Interlocked.Increment(ref _captchaAnswerId);
    public long CaptchaQuestionId => Interlocked.Increment(ref _captchaQuestionId);


}
