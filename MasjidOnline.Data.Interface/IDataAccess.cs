using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Captcha;

namespace MasjidOnline.Data.Interface;

public interface IDataAccess
{
    ICaptchaQuestionRepository CaptchaQuestionRepository { get; }
    ICaptchaAnswerRepository CaptchaAnswerRepository { get; }

    Task<int> SaveAsync();
}
