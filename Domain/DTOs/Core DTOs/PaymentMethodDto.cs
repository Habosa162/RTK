namespace RetailEcommerce.Domain.DTOs.Core_DTOs
{
    public class PaymentMethodDto
    {
        public int PaymentMethodId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}
