namespace MasjidOnline.Business.Interface.Model.Options;

public class Option
{
    public required ConnectionStrings ConnectionStrings { get; set; }

    public string RootUserEmailAddress { get; set; } = "root.dev@dev.masjidonline.org";

    public required Uri Uri { get; set; }
}
