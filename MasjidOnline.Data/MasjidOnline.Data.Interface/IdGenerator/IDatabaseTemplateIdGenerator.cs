using System.Threading.Tasks;

namespace MasjidOnline.Data.Interface.IdGenerator;

public interface IDatabaseTemplateIdGenerator
{
    int TableTemplateId { get; }

    Task InitializeAsync(IData data);
}
