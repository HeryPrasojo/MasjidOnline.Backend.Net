using System.Threading.Tasks;
using MasjidOnline.Data.Interface;

namespace MasjidOnline.Business.User.Interface;

public interface IInitializerBusiness
{
    Task InitializeAsync(IData _data);
}
