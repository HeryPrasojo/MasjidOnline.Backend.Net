using System.Threading.Tasks;

namespace MasjidOnline.Data.Interface;

public interface IEntityIdGenerator
{
    int CaptchaQuestionId { get; }

    Task InitializeAsync();
}
