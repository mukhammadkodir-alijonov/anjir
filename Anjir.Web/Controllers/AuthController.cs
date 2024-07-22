using Anjir.Web.Models;
using Anjir.Web.Service.IService;
using Anjir.Web.Utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Anjir.Web.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpGet]
        public IActionResult Login()
        {
            LoginRequestDto loginRequestDto = new();
            return View(loginRequestDto);
        }
        [HttpGet]
        public IActionResult Register(RegistrationRequestDto registrationRequestDto)
        {
            var roleList = new List<SelectListItem>()
            {
                new SelectListItem() { Text = SD.RoleAdmin, Value = SD.RoleAdmin },
                new SelectListItem() { Text = SD.RoleCustomer, Value = SD.RoleCustomer }
            };
            ViewBag.RoleList = roleList;
            return View();
        }
        public IActionResult Logout()
        {
            return View();
        }
    }
}
