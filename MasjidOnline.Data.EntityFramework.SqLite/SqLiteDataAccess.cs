﻿using MasjidOnline.Data.Interface;

namespace MasjidOnline.Data.EntityFramework.SqLite;

public class SqLiteDataAccess(DataContext _dataContext) : DataAccess(_dataContext), IDataAccess
{

}
