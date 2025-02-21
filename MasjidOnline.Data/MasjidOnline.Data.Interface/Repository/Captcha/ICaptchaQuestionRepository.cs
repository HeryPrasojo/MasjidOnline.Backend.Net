using System.Collections.Generic;
using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Model.Captcha;
using MasjidOnline.Entity.Captcha;

namespace MasjidOnline.Data.Interface.Repository.Captcha;

public interface ICaptchaQuestionRepository
{
    Task AddAndSaveAsync(CaptchaQuestion captchaQuestion);
    Task AddAsync(CaptchaQuestion captchaQuestion);
    Task<IEnumerable<CaptchaQuestionForInfaqAddByAnonym>> GetForInfaqAddByAnonymAsync(int sessionId);
    Task<CaptchaQuestionForAnswerAdd?> GetForAnswerAddAsync(int sessionId);
    Task<CaptchaQuestionForAdd?> GetForAddAsync(int sessionId);
    Task<IEnumerable<int>> GetIdsBySessionIdAsync(int sessionId);
    Task<int> GetMaxIdAsync();
}
