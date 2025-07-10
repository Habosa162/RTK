using RetailEcommerce.Domain.Models.CORE;

namespace RetailEcommerce.Domain.Models.Core
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string? ImgUrl { get; set; }
        public bool IsDeleted { get; set; } = false;
        public bool IsAvailable { get; set; } = true;
        public int BrandId { get; set; }
        public Brand Brand { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
