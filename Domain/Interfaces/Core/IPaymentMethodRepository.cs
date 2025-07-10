using RetailEcommerce.Domain.DTOs.Core_DTOs;
using RetailEcommerce.Domain.Models.CORE;

namespace RetailEcommerce.Domain.Interfaces.Core
{
    public interface IPaymentMethodRepository : IGenericRepository<PaymentMethod,PaymentMethodDto>
    {
    }
}
