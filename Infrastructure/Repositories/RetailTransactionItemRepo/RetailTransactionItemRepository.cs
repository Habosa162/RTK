using Microsoft.EntityFrameworkCore;
using RetailEcommerce.Domain.Interfaces.IRetailTransactionItem;
using RetailEcommerce.Domain.Models.RETAIL;
using RetailEcommerce.Infrastructure.Data;

namespace RetailEcommerce.Infrastructure.Repositories.RetailTransactionItemRepo
{
    public class RetailTransactionItemRepository : IRetailTransactionItemRepository
    {
        private readonly ApplicationDbContext _context;

        public RetailTransactionItemRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<RetailTransactionItem>> GetAllAsync()
        {
            return await _context.RetailTransactionItems
                .Include(i => i.Product)
                .Include(i => i.Transaction)
                .ToListAsync();
        }

        public async Task<RetailTransactionItem> GetByIdAsync(int id)
        {
            return await _context.RetailTransactionItems
                .Include(i => i.Product)
                .Include(i => i.Transaction)
                .FirstOrDefaultAsync(i => i.TransactionItemId == id);
        }

        public async Task AddAsync(RetailTransactionItem item)
        {
            _context.RetailTransactionItems.Add(item);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(RetailTransactionItem item)
        {
            _context.RetailTransactionItems.Update(item);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var item = await _context.RetailTransactionItems.FindAsync(id);
            if (item != null)
            {
                _context.RetailTransactionItems.Remove(item);
                await _context.SaveChangesAsync();
            }
        }
    }
}
