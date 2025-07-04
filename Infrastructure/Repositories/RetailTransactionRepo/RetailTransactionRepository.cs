using Microsoft.EntityFrameworkCore;
using RetailEcommerce.Domain.Interfaces.IRetailTransaction;
using RetailEcommerce.Domain.Models.RETAIL;
using RetailEcommerce.Infrastructure.Data;

namespace RetailEcommerce.Infrastructure.Repositories.RetailTransactionRepo
{
    public class RetailTransactionRepository : IRetailTransactionRepository
    {
        private readonly ApplicationDbContext _context;

        public RetailTransactionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<RetailTransaction>> GetAllAsync()
        {
            return await _context.RetailTransactions
                .Include(t => t.Customer)
                .Include(t => t.Items)
                .Include(t => t.Payments)
                .ToListAsync();
        }

        public async Task<RetailTransaction> GetByIdAsync(int id)
        {
            return await _context.RetailTransactions
                .Include(t => t.Customer)
                .Include(t => t.Items)
                .Include(t => t.Payments)
                .FirstOrDefaultAsync(t => t.TransactionId == id);
        }

        public async Task AddAsync(RetailTransaction transaction)
        {
            _context.RetailTransactions.Add(transaction);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(RetailTransaction transaction)
        {
            _context.RetailTransactions.Update(transaction);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var transaction = await _context.RetailTransactions.FindAsync(id);
            if (transaction != null)
            {
                _context.RetailTransactions.Remove(transaction);
                await _context.SaveChangesAsync();
            }
        }
    }
}
