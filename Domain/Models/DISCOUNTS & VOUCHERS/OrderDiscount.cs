using RetailEcommerce.Domain.Models.E_COMMERCE;

namespace RetailEcommerce.Domain.Models.DISCOUNTS___VOUCHERS
{
    public class OrderDiscount
    {
        public int OrderDiscountId { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int DiscountId { get; set; }
        public Discount Discount { get; set; }
        public decimal AppliedValue { get; set; }
    }
}
