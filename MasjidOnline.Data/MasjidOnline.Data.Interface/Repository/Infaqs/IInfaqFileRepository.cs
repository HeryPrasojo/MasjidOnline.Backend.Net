using System.Threading.Tasks;
using MasjidOnline.Entity.Infaqs;

namespace MasjidOnline.Data.Interface.Repository.Infaqs;

public interface IInfaqFileRepository
{
    Task AddAsync(InfaqFile transactionFile);
    Task<int> GetMaxIdAsync();
}
