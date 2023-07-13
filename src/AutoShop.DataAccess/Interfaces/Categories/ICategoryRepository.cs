using AutoShop.DataAccess.Common.Interfaces;
using AutoShop.Domain.Entities.Categories;

namespace AutoShop.DataAccess.Interfaces.Categories;

public interface ICategoryRepository : IRepository<Category, Category>, IGetAll<Category>
{
    //Task<int> CreateAsync(Category category);
}
