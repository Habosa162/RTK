using Microsoft.EntityFrameworkCore;
using RetailEcommerce.Domain.Interfaces.IWareHouse;
using RetailEcommerce.Domain.Models.INVENTORY;
using RetailEcommerce.Infrastructure.Data;

namespace RetailEcommerce.Infrastructure.Repositories.WareHouseRepo
{
    public class WarehouseRepository : IWarehouseRepository
    {
        private readonly ApplicationDbContext _context;

        public WarehouseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Warehouse>> GetAllAsync() => await _context.Warehouses.ToListAsync();

        public async Task<Warehouse> GetByIdAsync(int id) => await _context.Warehouses.FindAsync(id);

        public async Task AddAsync(Warehouse warehouse) => await _context.Warehouses.AddAsync(warehouse);

        public void Update(Warehouse warehouse) => _context.Warehouses.Update(warehouse);

        public void Delete(Warehouse warehouse) => _context.Warehouses.Remove(warehouse);

        public async Task SaveAsync() => await _context.SaveChangesAsync();
    }
}
