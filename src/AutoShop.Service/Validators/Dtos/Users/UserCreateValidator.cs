using AutoShop.Service.Dtos.Users;
using FluentValidation;

namespace AutoShop.Service.Validators.Dtos.Users;

public class UserCreateValidator : AbstractValidator<UserCreateDto>
{
    public UserCreateValidator()
    {
        RuleFor(dto => dto.FirstName).NotNull().NotEmpty().WithMessage("Nameni kiritish majburiy")
            .MinimumLength(3).WithMessage("Name 3 ta belgidan kop bolishi kerak")
            .MaximumLength(20).WithMessage("Name 20 ta belgidan kam bolishi kerak");


        RuleFor(dto => dto.LastName).NotNull().NotEmpty().WithMessage("Surnameni kiritish majburiy")
            .MinimumLength(5).WithMessage("Surname 5 ta belgidan kop bolishi kerak")
            .MaximumLength(20).WithMessage("Surname 20 ta belgidan kam bolishi kerak");
        RuleFor(dto => dto.PhoneNumber).NotNull().NotEmpty().WithMessage("Telefon raqam kiritish majburiy")
            .Must(phone => PhoneNumberValidator.IsValid(phone)).WithMessage("Telefon raqam to'g'ri kiritilmadi");

        RuleFor(dto => dto.Email).NotEmpty().NotEmpty().WithMessage("Email is required bro!")
            .Must(email => EmailValidator.isValid(email)).WithMessage("Email is in correct!");

        RuleFor(dto => dto.Region).NotNull().NotEmpty().WithMessage("Region kiritish majburiy")
            .MinimumLength(3).WithMessage("Region 3 ta belgidan kop bolishi kerak")
            .MaximumLength(20).WithMessage("Region 20 ta belgidan kam bolishi kerak");

        RuleFor(dto => dto.PasswordHash).NotNull().NotEmpty().WithMessage("Password kiritish majburiy")
            .Must(password => PasswordValidator.IsStrongPassword(password).isValiid).WithMessage("Password togri kelmadi!");
        //
        //.MinimumLength(3).WithMessage("Password 8 ta belgidan kop bolishi kerak")
        //.MaximumLength(20).WithMessage("Password 20 ta belgidan kam bolishi kerak");

        
    }
}
