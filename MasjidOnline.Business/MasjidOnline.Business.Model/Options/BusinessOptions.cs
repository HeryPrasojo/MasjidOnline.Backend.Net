namespace MasjidOnline.Business.Model.Options;

public class BusinessOptions
{
    public required int PaymentExpire { get; set; }

    public required string RootUserEmailAddress { get; set; }

    public required UriOptions Uri { get; set; }
}
