using RetailEcommerce.Domain.Models.E_COMMERCE;
using System.ComponentModel.DataAnnotations;

namespace RetailEcommerce.Domain.Models.SHIPPING
{
    public class ShippingDetail
    {
        [Key]
        public int ShippingId { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int AddressId { get; set; }
        public ShippingAddress Address { get; set; }
        public string ShippingMethod { get; set; }
        public string TrackingNumber { get; set; }
        public string DeliveryStatus { get; set; }
        public DateTime? ShippedAt { get; set; }
        public DateTime? DeliveredAt { get; set; }
    }
}
