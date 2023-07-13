using System.ComponentModel.DataAnnotations;

namespace AutoShop.Domain.Entities.Sellers;

public class Seller : Auditable
{
    public long SellerId { get; set; }

    [MaxLength(50)]
    public string FirstName { get; set; } = string.Empty;

    [MaxLength(50)]
    public string LastName { get; set; } = string.Empty;

    public DateTime BirthDate { get; set; }

    public string PhoneNumber { get; set; } = string.Empty;

    public string Region { get; set; } = string.Empty;
}

