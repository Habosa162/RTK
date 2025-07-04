using RetailEcommerce.Domain.Models.SHIPPING;

namespace RetailEcommerce.Domain.Interfaces.IShippingAddress
{
    public interface IShippingAddressRepository
    {
        Task<IEnumerable<ShippingAddress>> GetAllAsync();
        Task<ShippingAddress> GetByIdAsync(int id);
        Task AddAsync(ShippingAddress address);
        Task UpdateAsync(ShippingAddress address);
        Task DeleteAsync(int id);
    }
}
