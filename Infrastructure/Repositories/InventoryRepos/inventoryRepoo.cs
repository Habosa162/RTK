using Microsoft.EntityFrameworkCore;
using RetailEcommerce.Domain.Interfaces.IInventory;
using RetailEcommerce.Domain.Models.INVENTORY;
using RetailEcommerce.Infrastructure.Data;

namespace RetailEcommerce.Infrastructure.Repositories.InventoryRepos
{
    public class inventoryRepoo : IInventoryRepository
    {
        private readonly ApplicationDbContext _context;

        public inventoryRepoo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Inventory>> GetAllAsync()
        {
            return await _context.Inventories
                                 .Include(i => i.Product)
                                 .ToListAsync();
        }

        public async Task<Inventory> GetByIdAsync(int id)
        {
            return await _context.Inventories
                                 .Include(i => i.Product)
                                 .FirstOrDefaultAsync(i => i.InventoryId == id);
        }

        public async Task AddAsync(Inventory inventory)
        {
            _context.Inventories.Add(inventory);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Inventory inventory)
        {
            _context.Inventories.Update(inventory);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var inventory = await _context.Inventories.FindAsync(id);
            if (inventory != null)
            {
                _context.Inventories.Remove(inventory);
                await _context.SaveChangesAsync();
            }
        }
    }
}
