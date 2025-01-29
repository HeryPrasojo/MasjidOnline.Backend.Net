namespace MasjidOnline.Service.Mail.Interface.Model;

public class MailAddress
{
    public MailAddress(string name, string address)
    {
        Address = address;
        Name = name;
    }

    public string Address { get; set; }

    public string Name { get; set; }
}
