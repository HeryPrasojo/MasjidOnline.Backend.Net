using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Datas;

namespace MasjidOnline.Business.User.Interface.Model.Internal;

public interface IGetOneBusiness
{
    Task<GetOneResponse> GetAsync(IUserData _userData, GetOneRequest getOneRequest);
}
