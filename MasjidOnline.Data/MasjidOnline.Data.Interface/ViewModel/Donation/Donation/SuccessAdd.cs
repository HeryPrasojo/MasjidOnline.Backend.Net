using System;
using MasjidOnline.Entity.Donation;

namespace MasjidOnline.Data.Interface.ViewModel.Donation.Donation;

public class SuccessAdd
{
    public required DateTime DateTime { get; set; }

    public required DonationStatus Status { get; set; }
}



