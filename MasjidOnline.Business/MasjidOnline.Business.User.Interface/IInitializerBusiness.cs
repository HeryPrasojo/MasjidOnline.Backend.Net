using System.Threading.Tasks;
using MasjidOnline.Data.Interface;
using MasjidOnline.Data.Interface.Datas;

namespace MasjidOnline.Business.User.Interface;

public interface IInitializerBusiness
{
    Task InitializeAsync(IDataTransaction dataTransaction, IUserDatabase _userDatabase, IAuditDatabase _auditDatabase);
}
