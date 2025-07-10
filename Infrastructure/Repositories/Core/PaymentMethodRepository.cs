using Microsoft.EntityFrameworkCore;
using RetailEcommerce.Domain.DTOs.Core_DTOs;
using RetailEcommerce.Domain.Interfaces.Core;
using RetailEcommerce.Domain.Models.CORE;
using RetailEcommerce.Infrastructure.Data;

namespace RetailEcommerce.Infrastructure.Repositories.Core
{
    public class PaymentMethodRepository : IPaymentMethodRepository
    {
        private readonly ApplicationDbContext _context;
        public PaymentMethodRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<PaymentMethod> AddAsync(PaymentMethodDto dto)
        {
            try
            {
                if (dto == null) return null;
                var paymentMethod = new PaymentMethod
                {
                    Name = dto.Name,
                    Description = dto.Description,
                    IsActive = dto.IsActive
                };
                var createdPaymentMethod = await _context.PaymentMethods.AddAsync(paymentMethod);
                return await _context.SaveChangesAsync() > 0 ? createdPaymentMethod.Entity : null;
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
                var paymentMethod = _context.PaymentMethods.FirstOrDefault(p => p.PaymentMethodId == id);
                if (paymentMethod == null) return false;
                paymentMethod.IsActive = false;
                _context.PaymentMethods.Update(paymentMethod);
                return await _context.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<IEnumerable<PaymentMethod>> GetAllAsync(int pageNumber, int pageSize)
        {
            try
            {
               return await _context.PaymentMethods
                    .Where(p => p.IsActive)
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<PaymentMethod> GetByIdAsync(int id)
        {
            try
            {
               return await _context.PaymentMethods
                    .FirstOrDefaultAsync(p => p.PaymentMethodId == id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<PaymentMethod> UpdateAsync(int id, PaymentMethodDto dto)
        {
            try
            {
                var method = await _context.PaymentMethods.FirstOrDefaultAsync(p => p.PaymentMethodId == id);
                if (method == null) return null;
                method.Name = dto.Name;
                method.Description = dto.Description;
                method.IsActive = dto.IsActive;
                var updatedMethod = _context.PaymentMethods.Update(method);
                return await _context.SaveChangesAsync() > 0 ? updatedMethod.Entity : null;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
