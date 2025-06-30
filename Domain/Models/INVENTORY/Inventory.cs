using RetailEcommerce.Domain.Models.Core;

namespace RetailEcommerce.Domain.Models.INVENTORY
{
    public class Inventory
    {
        public int InventoryId { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public string LocationType { get; set; } // Warehouse or Branch
        public int LocationId { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
