using System.Threading.Tasks;

namespace MasjidOnline.Data.Interface;

public interface ICaptchaEntityIdGenerator
{
    long CaptchaQuestionId { get; }
    long CaptchaAnswerId { get; }

    Task InitializeAsync(ICaptchaData captchaData);
}
