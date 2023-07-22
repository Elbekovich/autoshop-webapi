namespace AutoShop.Domain.Entities.Cars;

public class Car : Auditable
{
    public string Category { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;

    public string ImagePath { get; set; } = string.Empty;

    public string Color { get; set; } = string.Empty;

    public string Type { get; set; } = string.Empty;

    public string TransmissionIsAutomatic { get; set; } = string.Empty;

    public int MadeAt { get; set; }

    public string Price { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    //public long CarID { get; set; }

    public string Probeg { get; set; } = string.Empty;

    public string Manzil { get; set; } = string.Empty;

    public long UserId { get; set; }
}

