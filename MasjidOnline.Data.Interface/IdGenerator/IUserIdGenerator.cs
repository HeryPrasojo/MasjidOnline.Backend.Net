using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Datas;

namespace MasjidOnline.Data.Interface.IdGenerator;

public interface IUserIdGenerator
{
    int UserId { get; }
    int UserEmailAddressId { get; }

    Task InitializeAsync(IUserData userData);
}
