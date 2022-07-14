using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using ToDoList.Contracts;
using ToDoList.Entities;

namespace ToDoList.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(User user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }

            User userValid = await _userRepository.UserValidation(user);

            if (userValid != null)
            {
                var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Authentication, userValid.Id.ToString()),
                    new Claim(ClaimTypes.Name, userValid.Name!),
                    new Claim(ClaimTypes.Email, userValid.Email!)
                };
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);
                var props = new AuthenticationProperties() {
                    ExpiresUtc = DateTime.Now.AddDays(1),
                    IsPersistent = true
                };

                HttpContext.SignInAsync( CookieAuthenticationDefaults.AuthenticationScheme,principal, props).Wait();
                return RedirectToAction("Index", "Home");
            }

            return View(user);
        }
    }
}
