using AutoShop.DataAccess.Interfaces.Categories;
using AutoShop.DataAccess.Utils;
using AutoShop.Domain.Entities.Categories;
using AutoShop.Domain.Exceptions.Categories;
using AutoShop.Service.Common.Helpers;
using AutoShop.Service.Dtos.Categories;
using AutoShop.Service.Interfaces.Categories;
using AutoShop.Service.Interfaces.Common;

namespace AutoShop.Service.Services.Categories;

public class CategoryService : ICategoryService
{
    private ICategoryRepository _categoryRepository;
    private IFileService _fileservice;

    public CategoryService(ICategoryRepository categoryRepository, IFileService fileService)
    {
        this._categoryRepository = categoryRepository;
        this._fileservice = fileService;
    }
    public async Task<long> CountAsync() =>  await _categoryRepository.CountAsync();


    public async Task<bool> CreateAsync(CategoryCreateDto dto)
    {
        string imagepath = await _fileservice.UploadImageAsync(dto.Image);
        Category category = new Category()
        {
            ImagePath = imagepath,
            Name = dto.Name,
            Description = dto.Description,
            CreatedAt = TimeHelper.GetDateTime(),
            UpdatedAt = TimeHelper.GetDateTime(),
        };
        var result = await _categoryRepository.CreateAsync(category);
        return result > 0;
    }

    public async Task<bool> DeleteAsync(long categoryId)
    {
        var category = await _categoryRepository.GetByIdAsync(categoryId);
        if (category is null) throw new CategoryNotFoundException();

        var result = await _fileservice.DeleteImageAsync(category.ImagePath);
        if (result is false) throw new ImageNotFoundException();

        var dbResult = await _categoryRepository.DeleteAsync(categoryId);
        return dbResult > 0;
    }

    public async Task<IList<Category>> GetAllAsync(PaginationParams @params)
    {
        var categories = await _categoryRepository.GetAllAsync(@params);
        return categories;
    }

    public async Task<Category> GetByIdAsync(long categoryId)
    {
        var category = await _categoryRepository.GetByIdAsync(categoryId);
        if (category is null) throw new CategoryNotFoundException();
        else return category;
    }

    public async Task<bool> UpdateAsync(long categoryId, CategoryUpdateDto dto)
    {
        var category = await _categoryRepository.GetByIdAsync(categoryId);
        if (category is null) throw new CategoryNotFoundException();

        // parse new items to category
        category.Name = dto.Name;
        category.Description = dto.Description;

        if (dto.Image is not null)
        {
            // delete old image
            var deleteResult = await _fileservice.DeleteImageAsync(category.ImagePath);
            if (deleteResult is false) throw new ImageNotFoundException();

            // upload new image
            string newImagePath = await _fileservice.UploadImageAsync(dto.Image);

            // parse new path to category
            category.ImagePath = newImagePath;
        }
        // else category old image have to save

        category.UpdatedAt = TimeHelper.GetDateTime();

        var dbResult = await _categoryRepository.UpdateAsync(categoryId, category);
        return dbResult > 0;
    }
}
