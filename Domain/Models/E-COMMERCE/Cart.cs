using RetailEcommerce.Domain.Models.CUSTOMERS___CREDIT;

namespace RetailEcommerce.Domain.Models.E_COMMERCE
{
    public class Cart
    {
        public int CartId { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public DateTime CreatedAt { get; set; }
        public ICollection<CartItem> Items { get; set; }
    }
}
