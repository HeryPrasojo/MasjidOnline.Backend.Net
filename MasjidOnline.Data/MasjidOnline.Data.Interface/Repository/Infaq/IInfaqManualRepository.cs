using System.Threading.Tasks;
using MasjidOnline.Entity.Infaq;

namespace MasjidOnline.Data.Interface.Repository.Infaq;

public interface IInfaqManualRepository
{
    Task AddAsync(InfaqManual infaqManual);
}
