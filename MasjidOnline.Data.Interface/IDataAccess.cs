using System.Threading.Tasks;

namespace MasjidOnline.Data.Interface;

public interface IDataAccess
{
    ICaptchaQuestionRepository CaptchaQuestionRepository { get; }

    Task<int> SaveAsync();
}
