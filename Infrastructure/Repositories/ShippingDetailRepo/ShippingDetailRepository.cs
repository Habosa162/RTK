using Microsoft.EntityFrameworkCore;
using RetailEcommerce.Domain.Interfaces.IShippingDetails;
using RetailEcommerce.Domain.Models.SHIPPING;
using RetailEcommerce.Infrastructure.Data;

namespace RetailEcommerce.Infrastructure.Repositories.ShippingDetailRepo
{
    public class ShippingDetailRepository : IShippingDetailRepository
    {
        private readonly ApplicationDbContext _context;

        public ShippingDetailRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ShippingDetail>> GetAllAsync()
        {
            return await _context.ShippingDetails
                                 .Include(d => d.Order)
                                 .Include(d => d.Address)
                                 .ToListAsync();
        }

        public async Task<ShippingDetail> GetByIdAsync(int id)
        {
            return await _context.ShippingDetails
                                 .Include(d => d.Order)
                                 .Include(d => d.Address)
                                 .FirstOrDefaultAsync(d => d.ShippingId == id);
        }

        public async Task AddAsync(ShippingDetail detail)
        {
            _context.ShippingDetails.Add(detail);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ShippingDetail detail)
        {
            _context.ShippingDetails.Update(detail);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var detail = await _context.ShippingDetails.FindAsync(id);
            if (detail != null)
            {
                _context.ShippingDetails.Remove(detail);
                await _context.SaveChangesAsync();
            }
        }
    }
}
