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

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var branch =  await _context.Branches.FirstOrDefaultAsync(b => b.BranchId == id);
                if (branch==null)
                {
                    return false; 
                }
                branch.isDeleted = true;
                _context.Branches.Update(branch);
                return await _context.SaveChangesAsync() > 0;
            }
            catch (DbUpdateException ex)
            {
                throw; 
            }
        }

        public async Task<IEnumerable<Branch>> GetAllAsync(int pageNumber, int pageSize)
        {
            try
            {
                return await _context.Branches
                    .Where(b=>b.isDeleted==false)
                    .Skip((pageNumber-1)* pageSize)
                    .Take(pageSize)
                    .ToListAsync(); 
            }
            catch (DbUpdateException ex) {
                throw; 
            }
        }

        public async Task<Branch> GetByIdAsync(int id)
        {
            try
            {
                return await _context.Branches.FirstOrDefaultAsync(b => b.BranchId == id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Branch> UpdateAsync(int id, BranchDTO branchDTO)
        {
            try
            {
                var branch =  await _context.Branches.FirstOrDefaultAsync(b => b.BranchId == id);
                if (branch == null)
                {
                    return null;
                }
                branch.Name = branchDTO.Name;
                branch.ContactNumber = branchDTO.ContactNumber;
                branch.Location = branchDTO.Location;
                _context.Branches.Update(branch);
                return await _context.SaveChangesAsync() > 0 ? branch : null;
            }
            catch(Exception ex)
            {
                throw;
            }
        }
    }
}
