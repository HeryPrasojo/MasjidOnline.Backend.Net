using MasjidOnline.Api.Model.User;
using MasjidOnline.Business.Interface.User;
using MasjidOnline.Data.Interface;

namespace MasjidOnline.Business.User;

public class LoginBusiness(IDataAccess dataAccess) : ILoginBusiness
{
    public void Register(RegisterRequest registerRequest)
    {

    }
}
