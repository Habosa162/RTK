using Microsoft.EntityFrameworkCore;
using RetailEcommerce.Domain.DTOs.Core_DTOs;
using RetailEcommerce.Domain.Models.CORE;
using RetailEcommerce.Infrastructure.Data;

namespace RetailEcommerce.Domain.Interfaces.Core
{
    public interface IPaymentRepository : IGenericRepository<Payment, PaymentDto>
    {
     
    }
}
