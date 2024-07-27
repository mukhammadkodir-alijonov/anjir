using Anjir.Services.ShoppingCartAPI.Models.Dto;

namespace Anjir.Services.ShoppingCartAPI.Service.IService
{
    public interface ICouponService
    {
        Task<CouponDto> GetCoupon(string couponCode);
    }
}
