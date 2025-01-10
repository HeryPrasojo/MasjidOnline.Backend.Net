using System.Threading.Tasks;
using MasjidOnline.Data.EntityFramework.Core;
using MasjidOnline.Data.Interface.Core;

namespace MasjidOnline.Data.EntityFramework;

public abstract class CoreData : ICoreData
{
    protected readonly CoreDataContext _coreDataContext;

    private ICoreSettingRepository? _coreSettingRepository;

    public CoreData(CoreDataContext coreDataContext)
    {
        _coreDataContext = coreDataContext;
    }

    public ICoreSettingRepository CoreSetting => _coreSettingRepository ??= new CoreSettingRepository(_coreDataContext);


    public async Task<int> SaveAsync()
    {
        return await _coreDataContext.SaveChangesAsync();
    }
}