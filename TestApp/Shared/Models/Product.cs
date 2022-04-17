namespace TestApp.Infrastructure.Models
{
    public class Product : BaseEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Rate { get; set; }
        public decimal Price { get; set; }

        public Guid InventoryId { get; set; }
        public Guid CategoryId { get; set; }

        public Inventory Inventory { get; set; }
        public Category Category { get; set; }
    }
}
