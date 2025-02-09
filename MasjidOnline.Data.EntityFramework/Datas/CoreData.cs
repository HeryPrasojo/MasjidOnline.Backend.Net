using MasjidOnline.Data.EntityFramework.DataContext;
using MasjidOnline.Data.EntityFramework.Repository.Core;
using MasjidOnline.Data.Interface.Datas;
using MasjidOnline.Data.Interface.Repository.Core;

namespace MasjidOnline.Data.EntityFramework.Datas;

public class CoreData(CoreDataContext _coreDataContext) : Data(_coreDataContext), ICoreData
{
    private ICoreSettingRepository? _coreSettingRepository;


    public ICoreSettingRepository CoreSetting => _coreSettingRepository ??= new CoreSettingRepository(_coreDataContext);
}