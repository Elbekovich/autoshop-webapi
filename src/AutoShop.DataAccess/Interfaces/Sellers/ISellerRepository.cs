using AutoShop.DataAccess.Common.Interfaces;
using AutoShop.Domain.Entities.Sellers;

namespace AutoShop.DataAccess.Interfaces.Sellers;

public interface ISellerRepository : IRepository<Seller, Seller>, IGetAll<Seller>, ISearchable<Seller>
{
}