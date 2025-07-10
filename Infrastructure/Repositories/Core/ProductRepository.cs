using Microsoft.EntityFrameworkCore;
using RetailEcommerce.Domain.DTOs.Core_DTOs;
using RetailEcommerce.Domain.Interfaces.Core;
using RetailEcommerce.Domain.Models.Core;
using RetailEcommerce.Domain.Models.CORE;
using RetailEcommerce.Infrastructure.Data;

namespace RetailEcommerce.Infrastructure.Repositories.Core
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;
        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Product> AddAsync(ProductDto dto)
        {
            try
            {
                if (dto == null) return null;
                var product = new Product() { 
                    Name = dto.Name,
                    Description = dto.Description,
                    Price = dto.Price,
                    IsAvailable = (bool)dto.IsAvailable,
                    ImgUrl = dto.ImgUrl,
                    BrandId = dto.BrandId,
                    CategoryId = dto.CategoryId,
                };
               var createdProduct =  await _context.Products.AddAsync(product); 
                return await _context.SaveChangesAsync() > 0 ? createdProduct.Entity : null;
            }
            catch (Exception ex) {
                throw; 
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var product = await _context.Products.FirstOrDefaultAsync(p => p.ProductId == id);
                if (product == null) return false;
                product.IsDeleted = true; 
                _context.Products.Update(product);
                return await _context.SaveChangesAsync() > 0;

            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Product>> GetAllAsync(int pageNumber, int pageSize)
        {
            try
            {
                return await _context.Products
                     .Where(p => !p.IsDeleted)
                     .Skip((pageNumber - 1) * pageSize)
                     .Take(pageSize)
                     .ToListAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            try
            {
                 return await _context.Products
                    .FirstOrDefaultAsync(p => p.ProductId == id && !p.IsDeleted);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Product> UpdateAsync(int id, ProductDto dto)
        {
            try
            {
                var product = await _context.Products.FirstOrDefaultAsync(p => p.ProductId == id);
                if (product == null) return null;
                product.Name = dto.Name;
                product.Description = dto.Description;
                product.Price = dto.Price;
                product.ImgUrl = dto.ImgUrl;
                product.BrandId = dto.BrandId;
                product.CategoryId = dto.CategoryId;
                product.UpdatedAt = DateTime.UtcNow;
                product.IsAvailable = (bool)dto.IsAvailable;
                _context.Products.Update(product);
                return await _context.SaveChangesAsync() > 0 ? product : null;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
