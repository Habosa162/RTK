using Microsoft.EntityFrameworkCore;
using RetailEcommerce.Domain.Interfaces.IShippingAddress;
using RetailEcommerce.Domain.Models.SHIPPING;
using RetailEcommerce.Infrastructure.Data;

namespace RetailEcommerce.Infrastructure.Repositories.ShippingAddressRepo
{
    public class ShippingAddressRepository : IShippingAddressRepository
    {
        private readonly ApplicationDbContext _context;

        public ShippingAddressRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ShippingAddress>> GetAllAsync()
        {
            return await _context.ShippingAddresses
                                 .Include(a => a.Customer)
                                 .ToListAsync();
        }

        public async Task<ShippingAddress> GetByIdAsync(int id)
        {
            return await _context.ShippingAddresses
                                 .Include(a => a.Customer)
                                 .FirstOrDefaultAsync(a => a.AddressId == id);
        }

        public async Task AddAsync(ShippingAddress address)
        {
            _context.ShippingAddresses.Add(address);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ShippingAddress address)
        {
            _context.ShippingAddresses.Update(address);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var address = await _context.ShippingAddresses.FindAsync(id);
            if (address != null)
            {
                _context.ShippingAddresses.Remove(address);
                await _context.SaveChangesAsync();
            }
        }
    }
}
