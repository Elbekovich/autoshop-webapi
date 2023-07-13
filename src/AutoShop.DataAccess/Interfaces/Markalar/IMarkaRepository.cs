using AutoShop.DataAccess.Common.Interfaces;
using AutoShop.Domain.Entities.Markalar;

namespace AutoShop.DataAccess.Interfaces.Markalar;

public interface IMarkaRepository : IRepository<Marka, Marka>, IGetAll<Marka>, ISearchable<Marka>
{

}
