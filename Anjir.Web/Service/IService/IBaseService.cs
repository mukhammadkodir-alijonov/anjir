using Anjir.Web.Models;

namespace Anjir.Web.Service.IService
{
    public interface IBaseService
    {
        Task<ResponseDto?> SendAsync(RequestDto requestDto,bool withBearer = true);
    }
}
