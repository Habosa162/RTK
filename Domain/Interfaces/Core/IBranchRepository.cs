using RetailEcommerce.Domain.DTOs.Core_DTOs;
using RetailEcommerce.Domain.Models.INVENTORY;

namespace RetailEcommerce.Domain.Interfaces.Core
{
    public interface IBranchRepository: IGenericRepository<Branch,BranchDTO>
    {
        Task<IEnumerable<Branch>> GetAllAsync(int pageNumber, int pageSize);
        Task<Branch> GetByIdAsync(int id);
        Task<Branch> AddAsync(BranchDTO branchDTO);
        Task<Branch> UpdateAsync(int id , BranchDTO branchDTO);
        Task<bool> DeleteAsync(int id);
    }
}
