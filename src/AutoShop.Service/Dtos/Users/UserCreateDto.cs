using AutoShop.Domain.Enums;

namespace AutoShop.Service.Dtos.Users;

public class UserCreateDto
{
    //[MaxLength(50)]
    public string FirstName { get; set; } = string.Empty;

    //[MaxLength(50)]
    public string LastName { get; set; } = string.Empty;

    //[MaxLength(50)]
    public string PhoneNumber { get; set; } = string.Empty;

    public bool PhoneNumberConfirmed { get; set; }

    //[MaxLength(9)]
    public string PassportSerialNumber { get; set; } = string.Empty;

    public bool IsMale { get; set; }

    public DateTime BirthDate { get; set; }

    public string Country { get; set; } = string.Empty;

    public string Region { get; set; } = string.Empty;

    public string PasswordHash { get; set; } = string.Empty;

    //public string Salt { get; set; } = string.Empty;

    public IdentityRole Role { get; set; }
}
