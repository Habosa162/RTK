using Microsoft.EntityFrameworkCore;
using RetailEcommerce.Domain.DTOs.Core_DTOs;
using RetailEcommerce.Domain.Interfaces.Core;
using RetailEcommerce.Domain.Models.Core;
using RetailEcommerce.Infrastructure.Data;

namespace RetailEcommerce.Infrastructure.Repositories.Core
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context; 
        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Category> AddAsync(CategoryDto dto)
        {
            try
            {

                var createdCategory = await _context.Categories.AddAsync(new Category
                {
                    Name = dto.Name,
                });

                return await _context.SaveChangesAsync() > 0 ? createdCategory.Entity : null;

            }
            catch (Exception ex)
            {
                throw; 
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var category = await _context.Categories.FirstOrDefaultAsync(c => c.CategoryId == id);
                if (category == null) return false;
                category.isDeleted = true;
                _context.Categories.Update(category);
                return await _context.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Category>> GetAllAsync(int pageNumber, int pageSize)
        {
            try
            {
                return await _context.Categories
                                    .Where(c => !c.isDeleted)
                                    .Skip((pageNumber - 1) * pageSize)
                                    .Take(pageSize)
                                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw;
                throw new NotImplementedException();
            }
        }

        public Task<Category> GetByIdAsync(int id)
        {
            try
            {
                return _context.Categories
                    .FirstOrDefaultAsync(c => c.CategoryId == id && !c.isDeleted);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Category> UpdateAsync(int id, CategoryDto dto)
        {
            try
            {
                var category = await _context.Categories
                    .FirstOrDefaultAsync(c => c.CategoryId == id && !c.isDeleted);
                if (category == null) return null;
                category.Name = dto.Name;
                _context.Categories.Update(category);
                return await _context.SaveChangesAsync() > 0 ? category : null;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
