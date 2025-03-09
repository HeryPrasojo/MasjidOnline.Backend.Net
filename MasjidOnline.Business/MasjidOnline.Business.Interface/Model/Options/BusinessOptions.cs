namespace MasjidOnline.Business.Interface.Model.Options;

public class BusinessOptions
{
    public required int PaymentManualExpire { get; set; }

    public required string RootUserEmailAddress { get; set; }

    public required UriOptions Uri { get; set; }
}
