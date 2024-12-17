using MasjidOnline.Api.Model.Donation;

namespace MasjidOnline.Business.Donation.Interface;

public interface IAnonymDonateBusiness
{
    Task<AnonymDonateResponse> DonateAsync(string? sessionId);
}
