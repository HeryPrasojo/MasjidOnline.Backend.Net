using System;
using MasjidOnline.Entity.Payments;

namespace MasjidOnline.Entity.Transactions;

public class Transaction
{
    public required int Id { get; set; }

    public required DateTime DateTime { get; set; }

    public required TransactionType Type { get; set; }

    public int UserId { get; set; }

    public string? MunfiqName { get; set; }

    public required decimal Amount { get; set; }


    public required PaymentType PaymentType { get; set; }

    public required PaymentStatus PaymentStatus { get; set; }

    // todo consider move to Payment db

    // PaymentType.Manual*

    public DateTime? ManualDateTime { get; set; }

    public string? ManualNotes { get; set; }
}
