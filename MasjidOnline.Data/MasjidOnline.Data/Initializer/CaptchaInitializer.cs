using System.Threading.Tasks;
using MasjidOnline.Data.Interface;
using MasjidOnline.Data.Interface.Definition;
using MasjidOnline.Data.Interface.Initializer;
using MasjidOnline.Entity.Captcha;

namespace MasjidOnline.Data.Initializer;

public abstract class CaptchaInitializer(ICaptchaDefinition _captchaDefinition) : ICaptchaInitializer
{
    public async Task InitializeDatabaseAsync(IData data)
    {
        var settingTableExists = await _captchaDefinition.CheckTableExistsAsync(nameof(CaptchaSetting));

        if (!settingTableExists)
        {
            await CreateTableCaptchaSettingAsync();
            await CreateTableCaptchaAsync();


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


    protected abstract Task<int> CreateTableCaptchaAsync();

    protected abstract Task<int> CreateTableCaptchaSettingAsync();
}
