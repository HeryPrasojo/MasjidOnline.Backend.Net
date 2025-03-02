using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Datas;

namespace MasjidOnline.Data.Interface.IdGenerator;

public interface IUsersIdGenerator
{
    int UserId { get; }
    byte[] PasswordCodeCode { get; }
    int InternalId { get; }

    Task InitializeAsync(IUsersData userData);
}
