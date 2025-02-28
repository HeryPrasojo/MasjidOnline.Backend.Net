﻿using MasjidOnline.Business.Infaq.Interface.Model.Infaq;
using MasjidOnline.Business.Interface.Model.Responses;
using MasjidOnline.Data.Interface.Datas;

namespace MasjidOnline.Business.Infaq.Interface;

public interface IInfaqGetManyDueBusiness
{
    Task<GetManyResponse<GetManyDueResponseRecord>> GetAsync(IInfaqsData _infaqsData, GetManyDueRequest getManyDueRequest);
}
