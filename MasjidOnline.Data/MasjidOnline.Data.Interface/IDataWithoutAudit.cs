﻿using System.Threading.Tasks;

namespace MasjidOnline.Data.Interface;

public interface IDataWithoutAudit : IData
{
    Task SaveAsync();
}
