using RetailEcommerce.Domain.Models.RETAIL;

namespace RetailEcommerce.Domain.Interfaces.IRetailTransaction
{
    public interface IRetailTransactionRepository
    {
        Task<IEnumerable<RetailTransaction>> GetAllAsync();
        Task<RetailTransaction> GetByIdAsync(int id);
        Task AddAsync(RetailTransaction transaction);
        Task UpdateAsync(RetailTransaction transaction);
        Task DeleteAsync(int id);
    }
}
