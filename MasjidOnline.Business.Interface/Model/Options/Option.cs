namespace MasjidOnline.Business.Interface.Model.Options;

public class Option
{
    public required ConnectionStrings ConnectionStrings { get; set; }

    public string RootUserEmailAddress { get; set; } = "root@api-dev.masjidonline.org";
}
