using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Core;

namespace MasjidOnline.Data.Interface;

public interface IEntityIdGenerator
{
    long CaptchaQuestionId { get; }
    long CaptchaAnswerId { get; }

    Task InitializeAsync(ICoreData dataAccess);
}
