using System.Threading.Tasks;
using MasjidOnline.Entity;

namespace MasjidOnline.Data.Interface;

public interface ICaptchaQuestionRepository
{
    Task AddAsync(CaptchaQuestion captchaQuestion);
}
