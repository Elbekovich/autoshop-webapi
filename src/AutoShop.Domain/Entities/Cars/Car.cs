namespace AutoShop.Domain.Entities.Cars;

public class Car : Auditable
{
    public long CategoryId { get; set; }

    public string Name { get; set; } = string.Empty;

    public string ImagePath { get; set; } = string.Empty;

    public string Color { get; set; } = string.Empty;

    public string Type { get; set; } = string.Empty;

    public bool TransmissionIsAutomatic { get; set; }

    public DateTime MadeAt { get; set; }

    public string Price { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public long CarID { get; set; }
}

