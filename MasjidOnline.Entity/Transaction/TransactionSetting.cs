using System.ComponentModel.DataAnnotations;

namespace MasjidOnline.Entity.Transaction;

public class TransactionSetting
{
    [Key]
    public required string Key { get; set; }

    public required string Value { get; set; }
}
