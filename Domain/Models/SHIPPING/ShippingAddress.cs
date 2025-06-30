using RetailEcommerce.Domain.Models.CUSTOMERS___CREDIT;

namespace RetailEcommerce.Domain.Models.SHIPPING
{
    public class ShippingAddress
    {
        public int AddressId { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public bool IsDefault { get; set; }
    }
}
