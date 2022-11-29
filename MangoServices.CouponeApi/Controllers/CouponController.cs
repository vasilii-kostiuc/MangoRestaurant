using MangoServices.CouponApi.Models.Dto;
using MangoServices.CouponApi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace MangoServices.CouponApi.Controllers
{
    [ApiController]
    [Route("api/coupon")]
    public class CouponController : Controller
    {
        private readonly ICouponRepository _couponRepository;
        protected ResponseDto _response;

        public CouponController(ICouponRepository couponRepository)
        {
            _couponRepository = couponRepository;
        }

        [HttpGet("{code}")]
        public async Task<ResponseDto> GetDiscountForCode(string code)
        {
            try
            {
                var coupon = await  _couponRepository.GetCouponByCode(code);
                _response.Result = coupon;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Errors = new List<string>() { ex.ToString() };
            }

            return _response;
        }
    }
}
