using System.Threading.Tasks;

namespace MasjidOnline.Data.Interface;

public interface IEntityIdGenerator
{
    long CaptchaQuestionId { get; }

    Task InitializeAsync(IDataAccess dataAccess);
}
