using System.ComponentModel.DataAnnotations;

namespace MasjidOnline.Entity.Transactions;

public class TransactionSetting
{
    [Key]
    public required string Key { get; set; }

    public required string Value { get; set; }
}
