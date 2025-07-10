using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using RetailEcommerce.Domain.DTOs.Core_DTOs;
using RetailEcommerce.Domain.Interfaces.Core;
using RetailEcommerce.Domain.Models.CORE;
using RetailEcommerce.Infrastructure.Data;

namespace RetailEcommerce.Infrastructure.Repositories.Core
{
    public class BrandRepository : IBrandRepository
    {
        private readonly ApplicationDbContext _context;
        public BrandRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Brand> AddAsync(BrandDto dto)
        {

            try
            {
                var brand = new Brand
                {
                    Name = dto.Name,
                };
                var addedBrand =  await _context.Brands.AddAsync(brand); 
                return await _context.SaveChangesAsync() > 0 ? addedBrand.Entity : null;
            }
            catch(Exception ex)
            {
                throw; 
            }
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var brand = await _context.Brands
                    .FirstOrDefaultAsync(b => b.BrandId == id); 
                if (brand == null){return false;}

                brand.isDeleted = true;
                _context.Brands.Update(brand);
                return await _context.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Brand>> GetAllAsync(int pageNumber, int pageSize)
        {
            try
            {
                return await _context.Brands
                  .Where(b => !b.isDeleted)
                  .Skip((pageNumber - 1) * pageSize)
                  .Take(pageSize)
                  .ToListAsync();
            }
            catch(Exception ex)
            {
                throw;
            }
      
        }

        public async Task<Brand> GetByIdAsync(int id)
        {
            try
            {
                return await _context.Brands
                    .FirstOrDefaultAsync(b => b.BrandId == id && !b.isDeleted);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Brand> UpdateAsync(int id, BrandDto dto)
        {
            try
            {
               var brand =  await _context.Brands.FirstOrDefaultAsync(b => b.BrandId == id && !b.isDeleted);
                if (brand == null) return null;
                brand.Name = dto.Name;
                //create activate and deactivate in the UI
                brand.isDeleted = dto.isDeleted; 
            }
            catch (Exception ex)
            {
                throw;
            }
            throw new NotImplementedException();
        }
    }
}
