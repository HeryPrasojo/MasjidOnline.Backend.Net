using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasjidOnline.Data.Interface.IdGenerator;

public interface IUserIdGenerator
{
    int UserId { get; }
    int UserEmailAddressId { get; }
}
