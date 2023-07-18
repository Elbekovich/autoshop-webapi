namespace AutoShop.Service.Dtos.Sellers;

public class SellerCreateDto
{
    //seller idni delete qilish kerak edi yana uylab kur
    public long  SellerId { get; set; }

    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public  DateOnly BirthDate { get; set; }

    public string PhoneNumber { get; set; } = string.Empty;

    public string Region { get; set; } = string.Empty;


}
