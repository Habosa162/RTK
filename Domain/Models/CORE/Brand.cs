namespace RetailEcommerce.Domain.Models.CORE
{
    public class Brand
    {
        public int BrandId { get; set; }
        public string Name { get; set; }
        public bool isDeleted { get; set; } = false; 
    }
}
