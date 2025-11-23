using System.Linq;
using System.Threading.Tasks;
using MasjidOnline.Business.Infaq.Expire.Mapper;
using MasjidOnline.Business.Infaq.Interface.Expire;
using MasjidOnline.Business.Infaq.Interface.Model.Expire;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Data.Interface;
using MasjidOnline.Service.Interface;

namespace MasjidOnline.Business.Infaq.Expire;

public class GetManyBusiness(IService _service) : IGetManyBusiness
{
    public async Task<Response<GetManyResponse<GetManyResponseRecord>>> GetAsync(
        IData _data,
        Session.Interface.Model.Session session,
        GetManyRequest? getManyRequest)
    {
        getManyRequest = _service.FieldValidator.ValidateRequired(getManyRequest);
        getManyRequest.Page = _service.FieldValidator.ValidateRequiredPlus(getManyRequest.Page);


        var take = 10;

        var getManyResult = await _data.Infaq.Expire.GetManyAsync(
            status: getManyRequest.Status.ToEntity(),
            skip: (getManyRequest.Page.Value - 1) * take,
            take: take);

        return new()
        {
            ResultCode = ResponseResultCode.Success,
            Data = new()
            {
                PageCount = ((getManyResult.RecordCount - 1) / take) + 1,
                RecordCount = _service.Localization[getManyResult.RecordCount, session.CultureInfo],
                Records = getManyResult.Records.Select(e => new GetManyResponseRecord
                {
                    DateTime = "",// e.DateTime,
                    Id = 0,//e.Id,
                           //InfaqId = 0,//e.InfaqId,
                    Status = "",//e.Status.ToModel(),
                    UpdateDateTime = "",//e.UpdateDateTime,
                    UpdateUserId = "",//e.UpdateUserId,
                                      //UserId = 0,//e.UserId,
                }),
            },
        };
    }
}
