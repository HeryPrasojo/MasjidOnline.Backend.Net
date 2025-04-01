using MasjidOnline.Business.Infaq.Interface.Infaq;

namespace MasjidOnline.Business.Infaq.Interface;

public interface IInfaqInfaqBusiness
{
    IAddAnonymBusiness AddAnonym { get; }
    IGetManyBusiness GetMany { get; }
    IGetManyDueBusiness GetManyDue { get; }
    IGetOneBusiness GetOne { get; }
    IGetOneDueBusiness GetOneDue { get; }
}
