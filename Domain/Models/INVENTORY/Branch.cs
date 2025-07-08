namespace RetailEcommerce.Domain.Models.INVENTORY
{
    public class Branch
    {
        public int BranchId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string ContactNumber { get; set; }
        public bool isDeleted { get; set; } = false; 
    }
}
