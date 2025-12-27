using System.Threading.Tasks;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Business.Model.Session;
using MasjidOnline.Business.Model.User.User;
using MasjidOnline.Data.Interface;

namespace MasjidOnline.Business.User.Interface.User;

public interface IVerifyRegisterBusiness
{
    Task<Response> VerifyAsync(Session session, IData _data, VerifyRegisterRequest verifyRegisterRequest);
}
