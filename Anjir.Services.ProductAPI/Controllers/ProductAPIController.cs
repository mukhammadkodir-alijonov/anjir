
using Anjir.Services.ProductAPI.Data;
using Anjir.Services.ProductAPI.Models;
using Anjir.Services.ProductAPI.Models.Dto;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Anjir.Services.ProductAPI.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductAPIController : ControllerBase   
    {
        private readonly AppDbContext _appDbContext;
        private ResponseDto _response;
        private readonly IMapper _mapper;

        public ProductAPIController(AppDbContext appDbContext,IMapper mapper)
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
                IEnumerable<Product> obList = _appDbContext.Products.ToList();
                _response.Result = _mapper.Map<IEnumerable<ProductDto>>(obList);
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
                Product ob = _appDbContext.Products.First(x => x.ProductId == id);
                _response.Result = _mapper.Map<ProductDto>(ob);
            }
            catch (Exception)
            {
                _response.IsSuccess = false;
                _response.Message = "Failed to retrieve data";
            }
            return _response;
        }
        [HttpPost]
        [Authorize(Roles ="ADMIN")]
        public ResponseDto Post([FromBody] ProductDto productDto)
        {
            try
            {
                Product ob = _mapper.Map<Product>(productDto);
                _appDbContext.Products.Add(ob);
                _appDbContext.SaveChanges();

                _response.Result = _mapper.Map<ProductDto>(ob);
            }
            catch (Exception)
            {
                _response.IsSuccess = false;
                _response.Message = "Failed to retrieve data";
            }
            return _response;
        }
        [HttpPut]
        [Authorize(Roles = "ADMIN")]
        public ResponseDto Put([FromBody] ProductDto productDto)
        {
            try
            {
                Product ob = _mapper.Map<Product>(productDto);
                _appDbContext.Products.Update(ob);
                _appDbContext.SaveChanges();

                _response.Result = _mapper.Map<ProductDto>(ob);
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
        [Authorize(Roles = "ADMIN")]
        public ResponseDto Delete(int id)
        {
            try
            {
                Product ob = _appDbContext.Products.First(x => x.ProductId == id);
                _appDbContext.Products.Remove(ob);
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
