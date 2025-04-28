using MasjidOnline.Business.Infaq.Interface.Infaq;

namespace MasjidOnline.Business.Infaq.Interface;

public interface IInfaqInfaqBusiness
{
    IAddByAnonymBusiness AddByAnonym { get; }
    IGetManyBusiness GetMany { get; }
    IGetOneBusiness GetOne { get; }
}
