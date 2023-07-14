using AutoShop.Service.Dtos.Users;
using FluentValidation;

namespace AutoShop.Service.Validators.Dtos.Users;

public class UserUpdateValidator : AbstractValidator<UserUpdateDto>
{
    public UserUpdateValidator()
    {
        RuleFor(dto => dto.FirstName).NotNull().NotEmpty().WithMessage("Nameni kiritish majburiy")
            .MinimumLength(3).WithMessage("Name 3 ta belgidan kop bolishi kerak")
            .MaximumLength(20).WithMessage("Name 20 ta belgidan kam bolishi kerak");

        RuleFor(dto => dto.LastName).NotNull().NotEmpty().WithMessage("Surnameni kiritish majburiy")
            .MinimumLength(5).WithMessage("Surname 5 ta belgidan kop bolishi kerak")
            .MaximumLength(20).WithMessage("Surname 20 ta belgidan kam bolishi kerak");

        RuleFor(dto => dto.PhoneNumber).NotNull().NotEmpty().WithMessage("PhoneNumberni kiritish majburiy")
            .MinimumLength(13).WithMessage("Number 13 ta boladi")
            .MaximumLength(13).WithMessage("Number 13 ta boladi");

        RuleFor(dto => dto.PassportSerialNumber).NotNull().NotEmpty().WithMessage("Pasport seriasini kiritish majburiy")
            .MinimumLength(9).WithMessage("Passpord seriasi 9 ta belgi boladi")
            .MaximumLength(9).WithMessage("Passpord seriasi 9 ta belgi boladi");

        RuleFor(dto => dto.Country).NotNull().NotEmpty().WithMessage("Country kiritish majburiy")
            .MinimumLength(3).WithMessage("Country 3 ta belgidan kop bolishi kerak")
            .MaximumLength(20).WithMessage("Country 20 ta belgidan kam bolishi kerak");

        RuleFor(dto => dto.Region).NotNull().NotEmpty().WithMessage("Region kiritish majburiy")
            .MinimumLength(3).WithMessage("Region 3 ta belgidan kop bolishi kerak")
            .MaximumLength(20).WithMessage("Region 20 ta belgidan kam bolishi kerak");

        RuleFor(dto => dto.PasswordHash).NotNull().NotEmpty().WithMessage("Password kiritish majburiy")
            .MinimumLength(3).WithMessage("Password 8 ta belgidan kop bolishi kerak")
            .MaximumLength(20).WithMessage("Password 20 ta belgidan kam bolishi kerak");

    }
}
