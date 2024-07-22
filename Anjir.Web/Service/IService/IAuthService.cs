using Anjir.Web.Models;

namespace Anjir.Web.Service.IService
{
    public interface IAuthService
    {
        Task<ResponseDto> LoginAsync(LoginRequestDto model);
        Task<ResponseDto> RegisterAsync(RegistrationRequestDto registrationRequestDto);
        Task<ResponseDto> AssignRoleAsnyc(RegistrationRequestDto registrationRequestDto);
    }
}
