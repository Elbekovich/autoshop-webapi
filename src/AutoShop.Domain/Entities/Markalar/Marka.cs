namespace AutoShop.Domain.Entities.Markalar;

public class Marka : Auditable
{

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string ImagePath { get; set; } = string.Empty;

    public long MarkaID { get; set; }

}
