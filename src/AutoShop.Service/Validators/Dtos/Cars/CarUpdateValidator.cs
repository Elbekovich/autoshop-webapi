using AutoShop.Service.Common.Helpers;
using AutoShop.Service.Dtos.Cars;
using FluentValidation;

namespace AutoShop.Service.Validators.Dtos.Cars
{
    public class CarUpdateValidator : AbstractValidator<CarUpdateDto>
    {
        public CarUpdateValidator()
        {
            RuleFor(dto => dto.Name).NotNull().NotEmpty().WithMessage("Car name is required!")
            .MaximumLength(30).WithMessage("Car name must be less than 30 characters");


            RuleFor(dto => dto.Color).NotNull().NotEmpty().WithMessage("Car color is required!")
            .MaximumLength(10).WithMessage("Car color must be less than 10 characters");


            RuleFor(dto => dto.Description).NotNull().NotEmpty().WithMessage("Description is required!")
            .MaximumLength(50).WithMessage("Description must be less than 50 characters");

            RuleFor(dto => dto.Price).NotNull().NotEmpty().WithMessage("Car price is required!");


            RuleFor(dto => dto.Type).NotEmpty().NotNull().WithMessage("Car type is required!");

            RuleFor(dto => dto.TransmissionIsAutomatic).NotNull().NotEmpty().WithMessage("Mashina avtomat yoki mehanik kiriting");

            RuleFor(dto => dto.MadeAt).NotEmpty().NotNull().WithMessage("Car date of manufacture required!");

            RuleFor(dto => dto.Probeg).NotNull().NotEmpty().WithMessage("Car the distance traveled required!");

            int MaxImageSizeMb = 5;
            RuleFor(dto => dto.ImagePath).NotEmpty().NotNull().WithMessage("Rasm quyish majburiy");
            RuleFor(dto => dto.ImagePath.Length).LessThan(MaxImageSizeMb * 1024 * 1024).WithMessage($"Image size {MaxImageSizeMb} MB dan kichik bulishi kerak");
            RuleFor(dto => dto.ImagePath.FileName).Must(predicate =>
            {
                FileInfo fileInfo = new FileInfo(predicate);
                return MediaHelper.GetImageExtensions().Contains(fileInfo.Extension);

            }).WithMessage("Bu fayl turi rasm faylining turi emas");
        }
    }
}
