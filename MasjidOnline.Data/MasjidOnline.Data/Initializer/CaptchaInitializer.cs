using System.Threading.Tasks;
using MasjidOnline.Data.Interface;
using MasjidOnline.Data.Interface.Definition;
using MasjidOnline.Entity.Captcha;

namespace MasjidOnline.Data.Initializer;

public abstract class CaptchaInitializer(ICaptchaDefinition _captchaDefinition)
{
    public async Task InitializeDatabaseAsync(IData data)
    {
        var settingTableExists = await _captchaDefinition.CheckTableExistsAsync(nameof(CaptchaSetting));

        if (!settingTableExists)
        {
            await CreateTableCaptchaSettingAsync();
            await CreateTablePassAsync();


            var captchaSetting = new CaptchaSetting
            {
                Id = (int)CaptchaSettingId.DatabaseVersion,
                Description = nameof(CaptchaSettingId.DatabaseVersion),
                Value = "1",
            };

            await data.Captcha.CaptchaSetting.AddAsync(captchaSetting);

            await data.Captcha.SaveAsync();
        }
    }


    protected abstract Task CreateTableCaptchaSettingAsync();
    protected abstract Task CreateTablePassAsync();
}
