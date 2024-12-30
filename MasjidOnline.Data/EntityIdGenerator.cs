using System.Threading;
using System.Threading.Tasks;
using MasjidOnline.Data.Interface;

namespace MasjidOnline.Data;

public class EntityIdGenerator(IDataAccess _dataAccess) : IEntityIdGenerator
{
    public async Task InitializeAsync()
    {
        _captchaQuestionId = await _dataAccess.CaptchaQuestionRepository.GetMaxIdAsync();
    }

    private int _captchaQuestionId;
    public int CaptchaQuestionId => Interlocked.Increment(ref _captchaQuestionId);


}
