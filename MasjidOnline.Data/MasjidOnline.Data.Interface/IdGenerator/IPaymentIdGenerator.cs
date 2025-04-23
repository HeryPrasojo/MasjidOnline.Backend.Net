using System.Threading.Tasks;

namespace MasjidOnline.Data.Interface.IdGenerator;

public interface IPaymentIdGenerator
{
    int TableId { get; }

    Task InitializeAsync(IData data);
}
