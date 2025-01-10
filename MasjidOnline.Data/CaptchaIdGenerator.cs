using System;
using System.Threading;
using MasjidOnline.Data.Interface;
using MasjidOnline.Data.Interface.Captcha;
using Microsoft.Extensions.DependencyInjection;

namespace MasjidOnline.Data;

public class CaptchaIdGenerator : ICaptchaIdGenerator
{
    private long _captchaAnswerId;
    private long _captchaQuestionId;

    public CaptchaIdGenerator(IServiceProvider serviceProvider)
    {
        using (var serviceScope = serviceProvider.CreateScope())
        {
            var captchaData = serviceScope.ServiceProvider.GetService<ICaptchaData>()
            ?? throw new ApplicationException($"Get ICaptchaData service fail");

            _captchaAnswerId = captchaData.CaptchaAnswer.GetMaxIdAsync().Result;
            _captchaQuestionId = captchaData.CaptchaQuestion.GetMaxIdAsync().Result;
        }
    }

    public long CaptchaAnswerId => Interlocked.Increment(ref _captchaAnswerId);
    public long CaptchaQuestionId => Interlocked.Increment(ref _captchaQuestionId);


}
