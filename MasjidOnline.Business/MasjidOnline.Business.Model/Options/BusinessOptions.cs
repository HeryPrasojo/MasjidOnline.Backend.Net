namespace MasjidOnline.Business.Model.Options;

public class BusinessOptions
{
    public required DirectoryOptions Directory { get; set; }

    /// <summary>
    /// PaymentExpire
    /// </summary>
    /// <remarks>in days</remarks>
    public required double PaymentExpire { get; set; }

    public required string RootUserEmailAddress { get; set; }

    public required string RootPersonName { get; set; }

    public required UriOptions Uri { get; set; }

    /// <summary>
    /// VerificationExpire
    /// </summary>
    /// <remarks>in minutes</remarks>
    public required double VerificationExpire { get; set; }

}
