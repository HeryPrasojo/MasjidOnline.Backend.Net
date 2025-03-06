using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Model.Captcha;

namespace MasjidOnline.Data.Interface.Repository.Captcha;

public interface ICaptchaRepository
{
    Task AddAndSaveAsync(Entity.Captcha.Captcha captcha);
    Task<IEnumerable<CaptchaForInfaqAddByAnonym>> GetForInfaqAddByAnonymAsync(int sessionId);
    Task<CaptchaForUpdate?> GetForUpdateAsync(int sessionId);
    Task<CaptchaForAdd?> GetForAddAsync(int sessionId);
    Task<int> GetMaxIdAsync();
    void SetAnswer(int id, float answerFloat, bool isMatched, DateTime updateDateTime);
}
