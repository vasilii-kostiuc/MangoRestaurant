using AutoMapper;
using MangoServices.CouponApi.DbContexts;
using MangoServices.CouponApi.Models;
using MangoServices.CouponApi.Models.Dto;
using Microsoft.EntityFrameworkCore;

namespace MangoServices.CouponApi.Repository
{
    public class CouponRepository:ICouponRepository
    {
        private ApplicationDbContext _dbContext;
        private IMapper _mapper;
        public CouponRepository(ApplicationDbContext dbContext,IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<CouponDto> GetCouponByCode(string couponeCode)
        {
            Coupon couponFromDb = await _dbContext.Coupons.FirstOrDefaultAsync(u => u.CouponeCode == couponeCode);
            return _mapper.Map<CouponDto>(couponFromDb);
        }
    }
}
