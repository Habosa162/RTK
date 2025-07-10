using RetailEcommerce.Domain.DTOs.Core_DTOs;
using RetailEcommerce.Domain.Models.Core;

namespace RetailEcommerce.Domain.Interfaces.Core
{
    public interface ICategoryRepository : IGenericRepository<Category, CategoryDto>
    {
    }
}
