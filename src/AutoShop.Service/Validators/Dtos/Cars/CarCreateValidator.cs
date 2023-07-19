using AutoShop.Service.Common.Helpers;
using AutoShop.Service.Dtos.Cars;
using FluentValidation;

namespace AutoShop.Service.Validators.Dtos.Cars
{
    public class CarCreateValidator : AbstractValidator<CarCreateDto>
    {
        public CarCreateValidator()
        {


            RuleFor(dto => dto.Name).NotNull().NotEmpty().WithMessage("Moshinani nameni kiriting")
            .MinimumLength(3).WithMessage("Name 3 ta belgidan kop bolishi kerak")
            .MaximumLength(50).WithMessage("Name 50 ta belgidan kam bo'lishi kerak");


            RuleFor(dto => dto.Color).NotNull().NotEmpty().WithMessage("Moshinani  rangini kiriting")
            .MinimumLength(1).WithMessage("rangi 1 ta harfdan kop boladi")
            .MaximumLength(10).WithMessage("rangi 10 ta harfdan kam boladi");


            RuleFor(dto => dto.Description).NotNull().NotEmpty().WithMessage("Moshina haqida qisqacha malumot kiriting")
            .MinimumLength(3).WithMessage("Malumot 10 ta belgidan kop bolishi kerak")
            .MaximumLength(50).WithMessage("Malumot 50 ta belgidan kam bo'lishi kerak");

            RuleFor(dto => dto.Price).NotNull().NotEmpty().WithMessage("Moshinani narxini kiriting");


            RuleFor(dto => dto.Type).NotEmpty().NotNull().WithMessage("Moshinani turini kiriting");

            RuleFor(dto => dto.TransmissionIsAutomatic).NotNull().NotEmpty().WithMessage("Mashina avtomat yoki mehanik kiriting");

            RuleFor(dto => dto.MadeAt).NotEmpty().NotNull().WithMessage("Moshina ishlab chiqarilgan sanani kiriting");

            RuleFor(dto => dto.Probeg).NotNull().NotEmpty().WithMessage("Moshina bosib otgan masofasini kiriting");

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
