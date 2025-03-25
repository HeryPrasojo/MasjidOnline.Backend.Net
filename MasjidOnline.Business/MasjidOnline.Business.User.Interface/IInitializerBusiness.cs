using System.Threading.Tasks;
using MasjidOnline.Data.Interface;
using MasjidOnline.Data.Interface.Databases;

namespace MasjidOnline.Business.User.Interface;

public interface IInitializerBusiness
{
    Task InitializeAsync(IDataTransaction dataTransaction, IUserDatabase _userDatabase, IAuditDatabase _auditDatabase);
}
