namespace RetailEcommerce.Domain.Interfaces
{
    public interface IGenericRepository<T,TDto>
    {
        Task<IEnumerable<T>> GetAllAsync(int pageNumber, int pageSize);
        Task<T> GetByIdAsync(int id);
        Task<T> AddAsync(TDto dto);
        Task<T> UpdateAsync(int id, TDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
