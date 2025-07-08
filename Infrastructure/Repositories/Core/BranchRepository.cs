using Microsoft.EntityFrameworkCore;
using RetailEcommerce.Domain.DTOs.Core_DTOs;
using RetailEcommerce.Domain.Interfaces.Core;
using RetailEcommerce.Domain.Models.INVENTORY;
using RetailEcommerce.Infrastructure.Data;

namespace RetailEcommerce.Infrastructure.Repositories.Core
{
    public class BranchRepository : IBranchRepository
    {
        private readonly ApplicationDbContext _context;
        public BranchRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Branch> AddAsync(BranchDTO branchDTO)
        {
            try
            {
                var branch = new Branch
                {
                    Name = branchDTO.Name,
                    ContactNumber = branchDTO.ContactNumber,
                    Location = branchDTO.Location,
                };

                var addedBranch = await _context.Branches.AddAsync(branch);
                var result = await _context.SaveChangesAsync();

                return result > 0 ? addedBranch.Entity : null;
            }
            catch (DbUpdateException ex)
            {
                //_logger.LogError(ex, "Failed to add Branch");
                throw; 
            }

        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Branch>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Branch> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Branch> UpdateAsync(BranchDTO branchDTO)
        {
            throw new NotImplementedException();
        }
    }
}
