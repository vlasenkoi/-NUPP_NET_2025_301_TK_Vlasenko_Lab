using System.ComponentModel.DataAnnotations;

namespace Shop.Infrastructure.Models
{
    public class ProductModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = "";

        public double Price { get; set; }
    }
}