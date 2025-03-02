using System.Threading.Tasks;
using MasjidOnline.Entity.Users;

namespace MasjidOnline.Data.Interface.Repository.Users;

public interface IInternalRepository
{
    Task AddAsync(Internal @internal);
}
