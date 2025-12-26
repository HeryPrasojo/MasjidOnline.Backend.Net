using System.Threading.Tasks;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Business.Model.User.User;
using MasjidOnline.Data.Interface;

namespace MasjidOnline.Business.User.Interface.User;

public interface IVerifySetPasswordBusiness
{
    Task<Response<LoginResponse>> VerifyAsync(Business.Model.Session.Session session, IData _data, VerifySetPasswordRequest? verifySetPasswordRequest);
}
