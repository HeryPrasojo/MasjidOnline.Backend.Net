using MasjidOnline.Data.EntityFramework.Repository.Person;
using MasjidOnline.Data.Interface.Databases;
using MasjidOnline.Data.Interface.Repository.Person;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.Databases;

public class PersonDatabase(DbContext _dbContext) : Database(_dbContext), IPersonDatabase
{
    private IPersonRepository? _personRepository;
    private IPersonSettingRepository? _personSettingRepository;


    public IPersonRepository Person => _personRepository ??= new PersonRepository(_dbContext);

    public IPersonSettingRepository PersonSetting => _personSettingRepository ??= new PersonSettingRepository(_dbContext);
}