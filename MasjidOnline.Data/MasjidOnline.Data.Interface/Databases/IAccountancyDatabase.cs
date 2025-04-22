using MasjidOnline.Data.Interface.Repository.Accountancy;
using MasjidOnline.Data.Interface.Repository.Database;

namespace MasjidOnline.Data.Interface.Databases;

public interface IAccountancyDatabase : IDatabase
{
    IAccountancySettingRepository AccountancySetting { get; }

    IExpenditureRepository Expenditure { get; }
}
