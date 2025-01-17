using MasjidOnline.Api.Model.User;
using MasjidOnline.Business.User.Interface;
using MasjidOnline.Data.Interface.Datas;

namespace MasjidOnline.Business.User;

public class LoginBusiness(ICoreData dataAccess) : ILoginBusiness
{
    public void Register(RegisterRequest registerRequest)
    {

    }
}
