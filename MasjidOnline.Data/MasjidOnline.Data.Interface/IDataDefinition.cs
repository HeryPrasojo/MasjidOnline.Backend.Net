﻿using System.Threading.Tasks;

namespace MasjidOnline.Data.Interface;

public interface IDataDefinition
{
    Task<bool> CheckTableExistsAsync(string name);
}
