using MangoServices.CouponApi.Models.Dto;

namespace MangoServices.CouponApi.Repository
{
    public interface ICouponRepository
    {
        Task<CouponDto> GetCouponByCode(string couponeCode);
    }
}
