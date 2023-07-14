using AutoShop.Service.Common.Helpers;
using AutoShop.Service.Dtos.Categories;
using FluentValidation;
using Npgsql.Internal.TypeHandlers.GeometricHandlers;

namespace AutoShop.Service.Validators.Dtos.Categories;

public class CategoryCreateValidator : AbstractValidator<CategoryCreateDto>
{
    public CategoryCreateValidator()
    {
        RuleFor(dto => dto.Name).NotNull().NotEmpty().WithMessage("Name kiritish majburiy")
            .MinimumLength(3).WithMessage("Name 3 ta belgidan kop bolishi kerak")
            .MaximumLength(50).WithMessage("Name 50 ta belgidan kam bo'lishi kerak");

        RuleFor(dto => dto.Description).NotNull().NotEmpty().WithMessage("Description kiritish majburiy")
            .MinimumLength(10).WithMessage("Descriptionni uzunlgi 10dan katta bolish kerak");
        
        int MaxImageSizeMb = 5;
        RuleFor(dto => dto.Image).NotEmpty().NotNull().WithMessage("Rasm quyish majburiy");
        RuleFor(dto => dto.Image.Length).LessThan(MaxImageSizeMb * 1024 * 1024).WithMessage($"Image size {MaxImageSizeMb} MB dan kichik bulishi kerak");
        RuleFor(dto => dto.Image.FileName).Must(predicate =>
        {
            FileInfo fileInfo = new FileInfo(predicate);
            return MediaHelper.GetImageExtensions().Contains(fileInfo.Extension);

        }).WithMessage("Bu fayl turi rasm faylining turi emas");            
    }
}
