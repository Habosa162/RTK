namespace RetailEcommerce.Domain.Models.CUSTOMERS___CREDIT
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public decimal CreditBalance { get; set; }
        public DateTime CreatedAt { get; set; }
        public ICollection<CustomerCredit> Credits { get; set; }
    }
}
