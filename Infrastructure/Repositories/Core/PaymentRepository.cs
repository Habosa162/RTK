using RetailEcommerce.Domain.DTOs.Core_DTOs;
using RetailEcommerce.Domain.Interfaces.Core;
using RetailEcommerce.Domain.Models.CORE;
using RetailEcommerce.Infrastructure.Data;

namespace RetailEcommerce.Infrastructure.Repositories.Core
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly ApplicationDbContext _context;
        public PaymentRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Payment> AddAsync(PaymentDto dto)
        {
            try
            {
                if (dto == null) return null;

                var createdPayment = await _context.Payments.AddAsync(new Payment
                {
                    Amount = dto.Amount,
                    PaidAt = dto.PaidAt,
                    OrderId = dto.OrderId,
                    PaymentMethodId = dto.PaymentMethodId,
                    RetailTransactionId = dto.RetailTransactionId,
                    PaymentReference = dto.PaymentReference
                });
                return await _context.SaveChangesAsync() > 0 ? createdPayment.Entity : null;

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
                var payment = await _context.Payments.FirstOrDefaultAsync(p => p.PaymentId == id);
                if (payment == null) return false;
                payment.IsDeleted = true;
                _context.Payments.Update(payment);
                return await _context.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Payment>> GetAllAsync(int pageNumber, int pageSize)
        {
            try
            {
                return await _context.Payments
                    .Where(p => !p.IsDeleted)
                    .OrderByDescending(p => p.PaidAt)
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public async Task<Payment> GetByIdAsync(int id)
        {
            try
            {
                return await _context.Payments
                    .FirstOrDefaultAsync(p => p.PaymentId == id && !p.IsDeleted);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<Payment> UpdateAsync(int id, PaymentDto dto)
        {
            try
            {
                var payemnt = await _context.Payments.FirstOrDefaultAsync(p => p.PaymentId == id && !p.IsDeleted);
                if (payemnt == null) return null;
                payemnt.Amount = dto.Amount;
                payemnt.PaidAt = dto.PaidAt;
                payemnt.OrderId = dto.OrderId;
                payemnt.PaymentMethodId = dto.PaymentMethodId;
                payemnt.RetailTransactionId = dto.RetailTransactionId;
                payemnt.PaymentReference = dto.PaymentReference;
                var updatedPayemnt = _context.Payments.Update(payemnt);
                return await _context.SaveChangesAsync() > 0 ? updatedPayemnt.Entity : null;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
