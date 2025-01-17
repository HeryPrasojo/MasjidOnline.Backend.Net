using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Datas;
using MasjidOnline.Data.Interface.Definition;
using MasjidOnline.Data.Interface.Initializer;
using MasjidOnline.Entity.Captcha;

namespace MasjidOnline.Data.Initializer;

public abstract class CaptchaInitializer(ICaptchaData _captchaData, ICaptchaDefinition _captchaDefinition) : ICaptchaInitializer
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

            await _captchaData.CaptchaSetting.AddAsync(captchaSetting);


            await CreateTableCaptchaQuestionAsync();

            await CreateTableCaptchaAnswerAsync();

            await _captchaData.SaveAsync();
        }
    }


    protected abstract Task<int> CreateTableCaptchaSettingAsync();

    protected abstract Task<int> CreateTableCaptchaQuestionAsync();

    protected abstract Task<int> CreateTableCaptchaAnswerAsync();
}
