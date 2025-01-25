using MasjidOnline.Business.User.Interface;
using MasjidOnline.Business.User.Interface.Model;
using MasjidOnline.Data.Interface.Datas;

namespace MasjidOnline.Business.User;

public class LoginBusiness(ICoreData dataAccess) : ILoginBusiness
{
    public void Register(RegisterRequest registerRequest)
    {

    }
}
