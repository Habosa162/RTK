using RetailEcommerce.Domain.Models.Core;
using RetailEcommerce.Domain.Models.CORE;

namespace RetailEcommerce.Domain.DTOs.Core_DTOs
{
    public class ProductDto
    {
        public int? ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string? ImgUrl { get; set; }
        public bool? IsDeleted { get; set; }
        public bool? IsAvailable { get; set; }
        public int BrandId { get; set; }
        public int CategoryId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
