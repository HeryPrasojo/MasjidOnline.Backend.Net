using System;
using MasjidOnline.Entity.Payments;
using MasjidOnline.Entity.User;

namespace MasjidOnline.Entity.Transactions;

public class Transaction
{
    public required long Id { get; set; }

    public required DateTime DateTime { get; set; }

    public required PaymentStatus PaymentStatus { get; set; }

    public required TransactionType Type { get; set; }

    public required UserType UserType { get; set; }

    public long? UserId { get; set; }

    public string? MunfiqName { get; set; }

    public required decimal Amount { get; set; }

    public required PaymentType PaymentType { get; set; }

    public string? ManualBankTransferNotes { get; set; }
}
