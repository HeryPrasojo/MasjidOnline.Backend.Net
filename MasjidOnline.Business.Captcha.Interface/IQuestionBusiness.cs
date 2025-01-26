using System.Threading.Tasks;
using MasjidOnline.Business.Captcha.Interface.Model;

namespace MasjidOnline.Business.Captcha.Interface;

public interface IQuestionBusiness
{
    Task<CreateQuestionResponse> CreateAsync(byte[]? sessionId);
}
