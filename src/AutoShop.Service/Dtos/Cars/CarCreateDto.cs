using Microsoft.AspNetCore.Http;

namespace AutoShop.Service.Dtos.Cars
{
    public class CarCreateDto
    {
        public long CategoryId { get; set; }

        public string Name { get; set; } = string.Empty;

        public IFormFile ImagePath { get; set; } = default!;

        public string Color { get; set; } = string.Empty;

        public string Type { get; set; } = string.Empty;

        public  bool TransmissionIsAutomatic { get; set; }

        public  DateTime MadeAt { get; set; }

        public string Price { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string Probeg { get; set; } = string.Empty;

    }
}
