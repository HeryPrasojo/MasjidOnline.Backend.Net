using System.Threading.Tasks;
using MasjidOnline.Data.Interface;

namespace MasjidOnline.Business.User.Interface;

public interface IUserBusiness
{
    IUserInternalBusiness Internal { get; }
    IUserUserBusiness User { get; }
    IUserPreferenceBusiness UserPreference { get; }

    Task InitializeAsync(IData _data);
}
