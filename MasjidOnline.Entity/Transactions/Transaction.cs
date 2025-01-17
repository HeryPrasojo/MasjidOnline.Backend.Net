using System;
using MasjidOnline.Entity.Payments;

namespace MasjidOnline.Entity.Transactions;

public class Transaction
{
    public required int Id { get; set; }

    public required DateTime CreateDateTime { get; set; }

    public required PaymentStatus PaymentStatus { get; set; }

    public required TransactionType Type { get; set; }

    // todo move to user, add 1 anonym user and refer UserId to it.

    public int UserId { get; set; }

    public string? MunfiqName { get; set; }

    public required decimal Amount { get; set; }

    public required PaymentType PaymentType { get; set; }


    public DateTime? ManualBankTransferDateTime { get; set; }

    public string? ManualBankTransferNotes { get; set; }
}
