using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Login(string email, string password)
        {
            if (!ModelState.IsValid)
            {
                return View(email, password);
            }

            User userValid = _userRepository.UserValidation(email, password);

            if(userValid != null){
                return RedirectToAction("Index","Home", new {UserId = userValid.Id});
            }

            return View(email,password);
        }
    }
}
