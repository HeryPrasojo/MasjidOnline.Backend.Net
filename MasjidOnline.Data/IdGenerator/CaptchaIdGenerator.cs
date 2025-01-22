using System.Threading;
using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Datas;
using MasjidOnline.Data.Interface.IdGenerator;

namespace MasjidOnline.Data.IdGenerator;

public class CaptchaIdGenerator : ICaptchaIdGenerator
{
    private int _captchaAnswerId;
    private int _captchaQuestionId;

    public async Task InitializeAsync(ICaptchaData captchaData)
    {
        _captchaAnswerId = await captchaData.CaptchaAnswer.GetMaxIdAsync();
        _captchaQuestionId = await captchaData.CaptchaQuestion.GetMaxIdAsync();
    }

    public int CaptchaAnswerId => Interlocked.Increment(ref _captchaAnswerId);

    public int CaptchaQuestionId => Interlocked.Increment(ref _captchaQuestionId);


}
