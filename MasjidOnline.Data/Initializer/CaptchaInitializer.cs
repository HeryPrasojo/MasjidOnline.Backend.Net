using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Datas;
using MasjidOnline.Data.Interface.Definition;
using MasjidOnline.Data.Interface.Initializer;
using MasjidOnline.Entity.Captcha;

namespace MasjidOnline.Data.Initializer;

public abstract class CaptchaInitializer(ICaptchaDefinition _captchaDefinition) : ICaptchaInitializer
{
    public async Task InitializeDatabaseAsync(ICaptchaData captchaData)
    {
        var settingTableExists = await _captchaDefinition.CheckTableExistsAsync("CaptchaSetting");

        if (!settingTableExists)
        {
            await CreateTableCaptchaSettingAsync();
            await CreateTableCaptchaQuestionAsync();
            await CreateTableCaptchaAnswerAsync();


            var captchaSetting = new CaptchaSetting
            {
                Id = (int)CaptchaSettingId.DatabaseVersion,
                Description = nameof(CaptchaSettingId.DatabaseVersion),
                Value = "1",
            };

            await captchaData.CaptchaSetting.AddAsync(captchaSetting);

            await captchaData.SaveAsync();
        }
    }


    protected abstract Task<int> CreateTableCaptchaSettingAsync();

    protected abstract Task<int> CreateTableCaptchaQuestionAsync();

    protected abstract Task<int> CreateTableCaptchaAnswerAsync();
}
