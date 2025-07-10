namespace RetailEcommerce.Domain.DTOs.Core_DTOs
{
    public class CategoryDto
    {
        public int? CategoryId { get; set; }
        public string Name { get; set; }
        public int? ParentCategoryId { get; set; }
    }
}
