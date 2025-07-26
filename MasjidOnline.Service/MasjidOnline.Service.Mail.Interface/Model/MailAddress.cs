namespace MasjidOnline.Service.Mail.Interface.Model;

public class MailAddress(string name, string address)
{
    public string Address { get; set; } = address;

    public string Name { get; set; } = name;
}
