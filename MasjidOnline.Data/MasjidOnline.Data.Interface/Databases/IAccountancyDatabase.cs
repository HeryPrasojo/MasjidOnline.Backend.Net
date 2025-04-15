using MasjidOnline.Data.Interface.Repository.Accountancy;

namespace MasjidOnline.Data.Interface.Databases;

public interface IAccountancyDatabase : IDatabase
{
    IAccountancySettingRepository AccountancySetting { get; }

    IExpenditureRepository Expenditure { get; }
}
