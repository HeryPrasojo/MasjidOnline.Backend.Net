using System;
using System.Threading.Tasks;

namespace MasjidOnline.Data.Interface.Repository.Audit;

public interface IPersonLogRepository
{
    Task AddAddAsync(int id, DateTime dateTime, int logUserId, Entity.Person.Person person);
    Task<int> GetMaxIdAsync();
}
