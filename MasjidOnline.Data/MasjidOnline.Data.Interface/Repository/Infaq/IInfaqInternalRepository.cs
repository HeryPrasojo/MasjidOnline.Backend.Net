using System.Threading.Tasks;
using MasjidOnline.Entity.Infaq;

namespace MasjidOnline.Data.Interface.Repository.Infaq;

public interface IInfaqInternalRepository
{
    Task AddAsync(InfaqInternal infaqInternal);
}
