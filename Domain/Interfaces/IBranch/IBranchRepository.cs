using RetailEcommerce.Domain.Models.Core;
using RetailEcommerce.Domain.Models.INVENTORY;

namespace RetailEcommerce.Domain.Interfaces.IBranch
{
    public interface IBranchRepository
    {
        Task<IEnumerable<Branch>> GetAllAsync();
        Task<Branch> GetByIdAsync(int id);
        Task AddAsync(Branch branch);
        Task UpdateAsync(Branch branch);
        Task DeleteAsync(int id);
    }
}
