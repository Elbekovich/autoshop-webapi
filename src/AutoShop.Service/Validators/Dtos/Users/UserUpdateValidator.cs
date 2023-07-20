using AutoShop.Service.Dtos.Users;
using FluentValidation;

namespace AutoShop.Service.Validators.Dtos.Users;

public class UserUpdateValidator : AbstractValidator<UserUpdateDto>
{
    public UserUpdateValidator()
    {
        RuleFor(dto => dto.FirstName).NotNull().NotEmpty().WithMessage("Firstname is required")
            .MaximumLength(30).WithMessage("Firstname must be less than 30 characters");

        RuleFor(dto => dto.LastName).NotNull().NotEmpty().WithMessage("Lastname is required")
            .MaximumLength(30).WithMessage("Lastname must be less than 30 characters");

        RuleFor(dto => dto.PhoneNumber).Must(phone => PhoneNumberValidator.IsValid(phone))
            .WithMessage("Phone number is invalid! ex: +998xxYYYAABB");

        RuleFor(dto => dto.Email).NotEmpty().NotEmpty().WithMessage("Email is required!")
            .Must(email => EmailValidator.isValid(email)).WithMessage("email is in incorrect!");

        RuleFor(dto => dto.Region).NotNull().NotEmpty().WithMessage("Region is required!")
            .MaximumLength(30).WithMessage("Region must be less than 30 characters");

        RuleFor(dto => dto.PasswordHash).NotNull().NotEmpty().WithMessage("Password is requuired")
            .Must(password => PasswordValidator.IsStrongPassword(password).isValiid).WithMessage("Password is not strong password!");
    }
}
