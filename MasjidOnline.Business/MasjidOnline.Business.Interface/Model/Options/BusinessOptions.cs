namespace MasjidOnline.Business.Interface.Model.Options;

public class BusinessOptions
{
    public required int PaymentManualExpired { get; set; }

    public required string RootUserEmailAddress { get; set; }

    public required UriOptions Uri { get; set; }
}
