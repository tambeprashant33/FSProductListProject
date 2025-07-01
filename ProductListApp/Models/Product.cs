using Swashbuckle.AspNetCore.Annotations;

namespace ProductListApp.Models
{
    public class Product
    {
        [SwaggerIgnore]
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

    }
}
