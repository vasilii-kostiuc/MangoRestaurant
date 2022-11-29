using System.ComponentModel.DataAnnotations;

namespace MangoServices.CouponApi.Models
{
    public class Coupon
    {
        [Key]
        public int CouponId { get; set; }
        public string CouponeCode { get; set; }
        public double DiscountAmount { get; set; }

    }
}
