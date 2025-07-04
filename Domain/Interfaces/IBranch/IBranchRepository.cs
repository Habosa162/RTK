using RetailEcommerce.Domain.Models.Core;

namespace RetailEcommerce.Domain.Interfaces.IBranch
{
    public interface IBranchRepository
    {
        Task<IEnumerable<Branch>> GetAllAsync();
        Task<Branch> GetByIdAsync(int id);
        Task AddAsync(Branch branch);
        void Update(Branch branch);
        void Delete(Branch branch);
        Task SaveAsync();
    }
}
