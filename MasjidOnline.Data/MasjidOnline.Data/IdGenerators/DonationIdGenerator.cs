using System.Threading;
using System.Threading.Tasks;
using MasjidOnline.Data.Interface;
using MasjidOnline.Data.Interface.IdGenerator;

namespace MasjidOnline.Data.IdGenerators;

public class DonationIdGenerator : IDonationIdGenerator
{
    private int _donationId;

    public async Task InitializeAsync(IData data)
    {
        _donationId = await data.Donation.Donation.GetMaxIdAsync();
    }

    public int DonationId => Interlocked.Increment(ref _donationId);
}


