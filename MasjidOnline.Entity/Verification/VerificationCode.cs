using System;

namespace MasjidOnline.Entity.Verification;

public class VerificationCode
{
    public required int Id { get; set; }

    public byte[] Code { get; set; } = default!;

    public int UserId { get; set; }

    public DateTime DateTime { get; set; }

    public VerificationCodeType Type { get; set; }

    public ContactType ContactType { get; set; }

    public string Contact { get; set; } = default!;


    public DateTime? UseDateTime { get; set; }
}
