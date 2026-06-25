using System;
using MasjidOnline.Entity.Donation;
using MasjidOnline.Entity.Payment;

namespace MasjidOnline.Data.Interface.ViewModel.Donation.Donation;

public class View
{
    public required DateTime DateTime { get; set; }

    public required string? MunfiqName { get; set; }

    public required decimal Amount { get; set; }

    public PaymentType PaymentType { get; set; }

    public required DonationStatus Status { get; set; }
}



