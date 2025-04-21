namespace MasjidOnline.Business.Accountancy.Interface;

public interface IAccountancyBusiness
{
    IAccountancyExpenditureBusiness Expenditure { get; }
}
