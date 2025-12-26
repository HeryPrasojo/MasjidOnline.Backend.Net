using System.Globalization;
using MasjidOnline.Business.Model;

namespace MasjidOnline.Business.Model.Session;

public class Session
{
    public required CultureInfo CultureInfo { get; set; }

    public int Id { get; set; }

    public int UserId { get; set; }


    public bool IsUserAnonymous => UserId == Constant.UserId.Anonymous;
}
