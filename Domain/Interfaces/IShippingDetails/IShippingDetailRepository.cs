using RetailEcommerce.Domain.Models.SHIPPING;

namespace RetailEcommerce.Domain.Interfaces.IShippingDetails
{
    public interface IShippingDetailRepository
    {
        Task<IEnumerable<ShippingDetail>> GetAllAsync();
        Task<ShippingDetail> GetByIdAsync(int id);
        Task AddAsync(ShippingDetail detail);
        Task UpdateAsync(ShippingDetail detail);
        Task DeleteAsync(int id);
    }
}
