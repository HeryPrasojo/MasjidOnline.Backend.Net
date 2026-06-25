using System;
using MasjidOnline.Entity.Donation;
using MasjidOnline.Entity.Payment;

namespace MasjidOnline.Data.Interface.ViewModel.Donation.Donation;

public class TableRecord
{
    public required int Id { get; set; }

    public required DateTime DateTime { get; set; }

    public required string? MunfiqName { get; set; }

    public required decimal Amount { get; set; }


    public required PaymentType PaymentType { get; set; }

    public required DonationStatus Status { get; set; }
}



