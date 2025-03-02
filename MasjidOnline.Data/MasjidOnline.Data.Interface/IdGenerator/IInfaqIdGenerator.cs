using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Datas;

namespace MasjidOnline.Data.Interface.IdGenerator;

public interface IInfaqIdGenerator
{
    int TransactionId { get; }
    int TransactionFileId { get; }

    Task InitializeAsync(IInfaqData infaqData);
}
