using RetailEcommerce.Domain.Interfaces.IBranch;
using RetailEcommerce.Domain.Models.Core;
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

        public async Task<IEnumerable<Branch>> GetAllAsync() => await _context.Branches.ToListAsync();

        public async Task<Branch> GetByIdAsync(int id) => await _context.Branches.FindAsync(id);

        public async Task AddAsync(Branch branch) => await _context.Branches.AddAsync(branch);

        public void Update(Branch branch) => _context.Branches.Update(branch);

        public void Delete(Branch branch) => _context.Branches.Remove(branch);

        public async Task SaveAsync() => await _context.SaveChangesAsync();
    }
}
