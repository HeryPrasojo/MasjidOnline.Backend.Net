using System;
using MasjidOnline.Entity.User;
using MasjidOnline.Entity.Verification;

namespace MasjidOnline.Data.Interface.ViewModel.Verification.VerificationCode;

public class OneByCode
{
    public required int Id { get; set; }

    public required int UserId { get; set; }

    public required DateTime DateTime { get; set; }

    public required VerificationCodeType Type { get; set; }

    public required ContactType ContactType { get; set; }

    public required string Contact { get; set; }

    public required DateTime? UseDateTime { get; set; }
}
