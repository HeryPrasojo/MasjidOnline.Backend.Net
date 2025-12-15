using System.Threading.Tasks;
using MasjidOnline.Business.User.Interface.User;
using MasjidOnline.Data.Interface;

namespace MasjidOnline.Business.User.User;

public class RegisterEmailBusiness() : IRegisterEmailBusiness
{
    // undone last
    public async Task RegisterEmailAsync(IData _data)
    {
        _data.User.register;
    }
}
