using Anjir.Services.ShoppingCartAPI.Models.Dto;

namespace Anjir.Services.ShoppingCartAPI.Service.IService
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetProducts();
    }
}
