using System.ComponentModel.DataAnnotations;

namespace TestApp.Domain.Dtos
{
    public class ProductModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Rate { get; set; }
        public decimal Price { get; set; }
        public string CategoryName { get; set; }

        public Guid CategoryId { get; set; }

        [Required]
        [StringLength(1000)]
        public string ImageUrl { get; set; }
    }
}
