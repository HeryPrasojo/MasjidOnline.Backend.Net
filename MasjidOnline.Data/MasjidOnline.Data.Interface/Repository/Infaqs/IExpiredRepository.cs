using System.Threading.Tasks;
using MasjidOnline.Entity.Infaqs;

namespace MasjidOnline.Data.Interface.Repository.Infaqs;

public interface IExpiredRepository
{
    Task AddAsync(Expired expired);
}
