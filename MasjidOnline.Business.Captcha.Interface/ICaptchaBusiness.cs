using System.Threading.Tasks;
using MasjidOnline.Api.Model.Captcha;

namespace MasjidOnline.Business.Captcha.Interface;

public interface ICaptchaBusiness
{
    Task<CreateResponse> CreateAsync(string? sessionId);
}
