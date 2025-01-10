using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Captcha;
using MasjidOnline.Entity.Captcha;

namespace MasjidOnline.Data.EntityFramework;

public abstract class CaptchaInitializer : CaptchaData, ICaptchaInitializer
{
    public CaptchaInitializer(
        CaptchaDataContext captchaDataContext,
        ICaptchaDefinition captchaDefinition) : base(captchaDataContext)
    {
        InitializeDatabaseAsync(captchaDefinition).Wait();
    }

    private async Task InitializeDatabaseAsync(ICaptchaDefinition captchaDefinition)
    {
        var settingTableExists = await captchaDefinition.CheckTableExistsAsync("CaptchaSetting");

        if (!settingTableExists)
        {
            await CreateTableCaptchaSettingAsync();

            var captchaSetting = new CaptchaSetting
            {
                Key = CaptchaSettingKey.DatabaseVersion,
                Value = "1",
            };

            await CaptchaSetting.AddAsync(captchaSetting);


            await CreateTableCaptchaQuestionAsync();

            await CreateTableCaptchaAnswerAsync();
        }

        await SaveAsync();
    }


    protected abstract Task<int> CreateTableCaptchaQuestionAsync();

    protected abstract Task<int> CreateTableCaptchaAnswerAsync();

    protected abstract Task<int> CreateTableCaptchaSettingAsync();
}
