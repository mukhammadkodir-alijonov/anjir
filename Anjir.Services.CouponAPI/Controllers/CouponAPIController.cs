using Anjir.Services.CouponAPI.Data;
using Anjir.Services.CouponAPI.Models;
using Anjir.Services.CouponAPI.Models.Dto;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Anjir.Services.CouponAPI.Controllers
{
    [Route("api/coupon")]
    [ApiController]
    public class CouponAPIController : ControllerBase   
    {
        private readonly AppDbContext _appDbContext;
        private ResponseDto _response;
        private readonly IMapper _mapper;

        public CouponAPIController(AppDbContext appDbContext,IMapper mapper)
        {
            _appDbContext = appDbContext;
            _response = new ResponseDto();
            _mapper = mapper;
        }
        [HttpGet]
        public ResponseDto Get()
        {
            try
            {
                IEnumerable<Coupon> obList = _appDbContext.Coupons.ToList();
                _response.Result = _mapper.Map<IEnumerable<CouponDto>>(obList);
            }
            catch (Exception)
            {
                _response.IsSuccess = false;
                _response.Message = "Failed to retrieve data";
            }
            return _response;
        }
        [HttpGet]
        [Route("{id:int}")]
        public ResponseDto Get(int id)
        {
            try
            {
                Coupon ob = _appDbContext.Coupons.First(x => x.CouponId == id);
                _response.Result = _mapper.Map<CouponDto>(ob);
            }
            catch (Exception)
            {
                _response.IsSuccess = false;
                _response.Message = "Failed to retrieve data";
            }
            return _response;
        }
        [HttpGet]
        [Route("GetByCode{code}")]
        public ResponseDto GetByCode(string code)
        {
            try
            {
                Coupon ob = _appDbContext.Coupons.First(x => x.CouponCode.ToLower() == code.ToLower());
                _response.Result = _mapper.Map<CouponDto>(ob);
            }
            catch (Exception)
            {
                _response.IsSuccess = false;
                _response.Message = "Failed to retrieve data";
            }
            return _response;
        }
        [HttpPost]
        public ResponseDto Post([FromBody] CouponDto couponDto)
        {
            try
            {
                Coupon ob = _mapper.Map<Coupon>(couponDto);
                _appDbContext.Coupons.Add(ob);
                _appDbContext.SaveChanges();

                _response.Result = _mapper.Map<CouponDto>(ob);
            }
            catch (Exception)
            {
                _response.IsSuccess = false;
                _response.Message = "Failed to retrieve data";
            }
            return _response;
        }
        [HttpPut]
        public ResponseDto Put([FromBody] CouponDto couponDto)
        {
            try
            {
                Coupon ob = _mapper.Map<Coupon>(couponDto);
                _appDbContext.Coupons.Update(ob);
                _appDbContext.SaveChanges();

                _response.Result = _mapper.Map<CouponDto>(ob);
            }
            catch (Exception)
            {
                _response.IsSuccess = false;
                _response.Message = "Failed to retrieve data";
            }
            return _response;
        }
        [HttpDelete]
        [Route("{id:int}")]
        public ResponseDto Delete(int id)
        {
            try
            {
                Coupon ob = _appDbContext.Coupons.First(x => x.CouponId == id);
                _appDbContext.Coupons.Remove(ob);
                _appDbContext.SaveChanges();
            }
            catch (Exception)
            {
                _response.IsSuccess = false;
                _response.Message = "Failed to retrieve data";
            }
            return _response;
        }
    }
}
