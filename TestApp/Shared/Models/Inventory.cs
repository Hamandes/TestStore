namespace TestApp.Infrastructure.Models
{
    public class Inventory : BaseEntity
    {
        public Guid Id { get; set; }
        public int Quantity { get; set; }
    }
}
