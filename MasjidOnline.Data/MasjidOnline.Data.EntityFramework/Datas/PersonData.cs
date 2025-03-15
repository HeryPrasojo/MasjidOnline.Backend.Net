using MasjidOnline.Data.EntityFramework.DataContext;
using MasjidOnline.Data.EntityFramework.Repository.Person;
using MasjidOnline.Data.Interface.Datas;
using MasjidOnline.Data.Interface.Repository.Person;

namespace MasjidOnline.Data.EntityFramework.Datas;

public class PersonData(PersonDataContext _personDataContext) : DataWithoutAudit(_personDataContext), IPersonData
{
    private IPersonSettingRepository? _personSettingRepository;


    public IPersonSettingRepository PersonSetting => _personSettingRepository ??= new PersonSettingRepository(_personDataContext);
}