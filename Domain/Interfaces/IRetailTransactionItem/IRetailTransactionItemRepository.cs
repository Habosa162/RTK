using RetailEcommerce.Domain.Models.RETAIL;

namespace RetailEcommerce.Domain.Interfaces.IRetailTransactionItem
{
    public interface IRetailTransactionItemRepository
    {
        Task<IEnumerable<RetailTransactionItem>> GetAllAsync();
        Task<RetailTransactionItem> GetByIdAsync(int id);
        Task AddAsync(RetailTransactionItem item);
        Task UpdateAsync(RetailTransactionItem item);
        Task DeleteAsync(int id);
    }
}
