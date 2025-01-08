using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Captcha;
using MasjidOnline.Entity.Captcha;

namespace MasjidOnline.Data.EntityFramework;

public abstract class CaptchaInitializer(
    CaptchaDataContext _captchaDataContext,
    ICaptchaDefinition _captchaDefinition) : CaptchaData(_captchaDataContext), ICaptchaInitializer
{
    public async Task InitializeDatabaseAsync()
    {
        var settingTableExists = await _captchaDefinition.CheckTableExistsAsync("CaptchaSetting");

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
