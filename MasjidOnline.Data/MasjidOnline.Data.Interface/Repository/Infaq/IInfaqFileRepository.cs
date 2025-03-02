using System.Threading.Tasks;
using MasjidOnline.Entity.Infaq;

namespace MasjidOnline.Data.Interface.Repository.Infaq;

public interface IInfaqFileRepository
{
    Task AddAsync(InfaqFile transactionFile);
    Task<int> GetMaxIdAsync();
}
