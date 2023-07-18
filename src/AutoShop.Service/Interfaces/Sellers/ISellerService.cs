using AutoShop.DataAccess.Utils;
using AutoShop.Domain.Entities.Categories;
using AutoShop.Domain.Entities.Sellers;
using AutoShop.Service.Dtos.Categories;
using AutoShop.Service.Dtos.Sellers;

namespace AutoShop.Service.Interfaces.Sellers;

public interface ISellerService
{
    public Task<bool> CreateAsync(SellerCreateDto dto);

    public Task<bool> DeleteAsync(long sellerId);

    public Task<long> CountAsync();

    public Task<IList<Seller>> GetAllAsync(PaginationParams @params);

    public Task<Seller> GetByIdAsync(long sellerId);

    public Task<bool> UpdateAsync(long sellerId, SellerUpdateDto dto);
}
