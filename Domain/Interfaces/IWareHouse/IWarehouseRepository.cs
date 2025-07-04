using RetailEcommerce.Domain.Models.INVENTORY;

namespace RetailEcommerce.Domain.Interfaces.IWareHouse
{
    public interface IWarehouseRepository
    {
        Task<IEnumerable<Warehouse>> GetAllAsync();
        Task<Warehouse> GetByIdAsync(int id);
        Task AddAsync(Warehouse warehouse);
        void Update(Warehouse warehouse);
        void Delete(Warehouse warehouse);
        Task SaveAsync();
    }
}
