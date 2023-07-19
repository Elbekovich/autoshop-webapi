using Microsoft.AspNetCore.Http;

namespace AutoShop.Service.Dtos.Cars
{
    public class CarUpdateDto
    {
        public string Category { get; set; } = string.Empty;

        public string Name { get; set; } = String.Empty;

        public IFormFile ImagePath { get; set; }  

        public string Color { get; set; } = String.Empty;

        public string Type { get; set; } = String.Empty;

        public string TransmissionIsAutomatic { get; set; } = string.Empty;

        public DateTime MadeAt { get; set; }

        public string Price { get; set; } = String.Empty;

        public string Description { get; set; } = String.Empty;

        public string Probeg { get; set; } = String.Empty;

        public string Manzil { get; set; } = string.Empty;

        //public  long  UserId { get; set; }
    }
}
