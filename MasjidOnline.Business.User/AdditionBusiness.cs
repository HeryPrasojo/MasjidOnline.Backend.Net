using System.Threading.Tasks;
using MasjidOnline.Api.Model.User;
using MasjidOnline.Business.User.Interface;
using MasjidOnline.Data.Interface.Datas;
using MasjidOnline.Service;

namespace MasjidOnline.Business.User;

public class AdditionBusiness : IAdditionBusiness
{
    public async Task<AddResponse> AddAsync(IUserData userData, UserSession userSession, AddRequest addRequest)
    {
        userData.;
    }
}
