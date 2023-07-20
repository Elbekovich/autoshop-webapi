using AutoShop.Service.Common.Helpers;
using AutoShop.Service.Dtos.Categories;
using FluentValidation;

namespace AutoShop.Service.Validators.Dtos.Categories;

public class CategoryCreateValidator : AbstractValidator<CategoryCreateDto>
{
    public CategoryCreateValidator()
    {
        RuleFor(dto => dto.Name).NotNull().NotEmpty().WithMessage("Name is required")
            .MaximumLength(30).WithMessage("Firstname must be less than 30 characters");

        RuleFor(dto => dto.Description).NotNull().NotEmpty().WithMessage("Description is required")
            .MaximumLength(50).WithMessage("Description must be less than 50 characters");

        int MaxImageSizeMb = 5;
        RuleFor(dto => dto.Image).NotEmpty().NotNull().WithMessage("Rasm quyish majburiy");
        RuleFor(dto => dto.Image.Length).LessThan(MaxImageSizeMb * 1024 * 1024).WithMessage($"Image size must be less than {MaxImageSizeMb} MB ");
        RuleFor(dto => dto.Image.FileName).Must(predicate =>
        {
            FileInfo fileInfo = new FileInfo(predicate);
            return MediaHelper.GetImageExtensions().Contains(fileInfo.Extension);
        }).WithMessage("Bu fayl turi rasm faylining turi emas");            
    }
}
