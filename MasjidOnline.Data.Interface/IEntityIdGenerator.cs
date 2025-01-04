using System.Threading.Tasks;

namespace MasjidOnline.Data.Interface;

public interface IEntityIdGenerator
{
    long CaptchaQuestionId { get; }
    long CaptchaAnswerId { get; }

    Task InitializeAsync(IDataAccess dataAccess);
}
