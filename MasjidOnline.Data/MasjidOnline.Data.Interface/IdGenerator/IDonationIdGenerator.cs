using System.Threading.Tasks;

namespace MasjidOnline.Data.Interface.IdGenerator;

public interface IDonationIdGenerator
{
    int DonationId { get; }

    Task InitializeAsync(IData data);
}

