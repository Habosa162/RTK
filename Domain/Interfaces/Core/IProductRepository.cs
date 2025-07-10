using RetailEcommerce.Domain.DTOs.Core_DTOs;
using RetailEcommerce.Domain.Models.Core;

namespace RetailEcommerce.Domain.Interfaces.Core
{
    public interface IProductRepository : IGenericRepository<Product,ProductDto>
    {
    }
}
