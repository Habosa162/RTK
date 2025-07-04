using Microsoft.EntityFrameworkCore;
using RetailEcommerce.Domain.Interfaces.IBranch;
using RetailEcommerce.Domain.Models.Core;
using RetailEcommerce.Domain.Models.INVENTORY;
using RetailEcommerce.Infrastructure.Data;

namespace RetailEcommerce.Infrastructure.Repositories.BranchRepo
{
    public class BranchRepository : IBranchRepository
    {
        private readonly ApplicationDbContext _context;

        public BranchRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Branch>> GetAllAsync()
        {
            return await _context.Branches.ToListAsync();
        }

        public async Task<Branch> GetByIdAsync(int id)
        {
            return await _context.Branches.FindAsync(id);
        }

        public async Task AddAsync(Branch branch)
        {
            _context.Branches.Add(branch);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Branch branch)
        {
            _context.Branches.Update(branch);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var branch = await _context.Branches.FindAsync(id);
            if (branch != null)
            {
                _context.Branches.Remove(branch);
                await _context.SaveChangesAsync();
            }
        }
    }
}
