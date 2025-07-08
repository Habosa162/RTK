using RetailEcommerce.Domain.DTOs.Core_DTOs;
using RetailEcommerce.Domain.Models.INVENTORY;

namespace RetailEcommerce.Domain.Interfaces.Core
{
    public interface IBranchRepository
    {
        Task<IEnumerable<Branch>> GetAllAsync();
        Task<Branch> GetByIdAsync(int id);
        Task<Branch> AddAsync(BranchDTO branchDTO);
        Task<Branch> UpdateAsync(BranchDTO branchDTO);
        Task DeleteAsync(int id);
    }
}
