using Business.Abstract;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class UserController : Controller
    {
        private readonly IAuthManager _authManager;

        public UserController(IAuthManager authManager)
        {
            _authManager = authManager;
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginDto loginDto)
        {
            var token = "test";
            token=_authManager.Login(loginDto);
            CookieOptions option = new();
            option.Expires=DateTime.UtcNow.AddMinutes(1);
            Response.Cookies.Append("token",token,option);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Register()
        {
           return View();

          }


        [HttpPost]
        public IActionResult Register(RegisterDto registerDto)
        {
            try
            {
                _authManager.Register(registerDto);
                return RedirectToAction("Login");
            }
            catch (Exception)
            {
                return View();
                
            }
          
        }
    }
}
