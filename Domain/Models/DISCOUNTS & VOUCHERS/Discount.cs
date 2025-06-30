namespace RetailEcommerce.Domain.Models.DISCOUNTS___VOUCHERS
{
    public class Discount
    {
        public int DiscountId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string DiscountType { get; set; } // Percentage or Fixed
        public decimal Value { get; set; }
        public bool IsActive { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string AppliesTo { get; set; }
    }
}
