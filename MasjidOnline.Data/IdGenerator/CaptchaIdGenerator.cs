using System;
using System.Threading;
using MasjidOnline.Data.Interface.Datas;
using MasjidOnline.Data.Interface.IdGenerator;
using Microsoft.Extensions.DependencyInjection;

namespace MasjidOnline.Data.IdGenerator;

// move to a new child folder MasjidOnline.Data.IdGenerator
public class CaptchaIdGenerator : ICaptchaIdGenerator
{
    private int _captchaAnswerId;
    private int _captchaQuestionId;

    public CaptchaIdGenerator(IServiceProvider serviceProvider)
    {
        using var serviceScope = serviceProvider.CreateScope();

        var captchaData = serviceScope.ServiceProvider.GetService<ICaptchaData>()
            ?? throw new ApplicationException($"Get ICaptchaData service fail");

        _captchaAnswerId = captchaData.CaptchaAnswer.GetMaxIdAsync().Result;
        _captchaQuestionId = captchaData.CaptchaQuestion.GetMaxIdAsync().Result;
    }

    public int CaptchaAnswerId => Interlocked.Increment(ref _captchaAnswerId);

    public int CaptchaQuestionId => Interlocked.Increment(ref _captchaQuestionId);


}
