using System.ComponentModel.DataAnnotations;

namespace RetailEcommerce.Domain.Interfaces.Core
{
    public class BrandDto
    {
        public int? BrandId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        public bool isDeleted { get; set; } 

    }
}