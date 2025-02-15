using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Model.User;
using MasjidOnline.Entity.Users;

namespace MasjidOnline.Data.Interface.Repository.Users;

public interface IPasswordCodeRepository
{
    Task AddAsync(PasswordCode passwordCode);
    Task<PasswordCodeForPasswordSet?> GetForPasswordSetAsync(byte[] code);
}
