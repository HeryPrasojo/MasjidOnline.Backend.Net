using MasjidOnline.Business.Infaq.Interface.Infaq;

namespace MasjidOnline.Business.Infaq.Interface;

public interface IInfaqInfaqBusiness
{
    IAddAnonymBusiness AddAnonym { get; }
    IGetManyBusiness GetMany { get; }
    IGetOneBusiness GetOne { get; }
}
