using Microsoft.AspNetCore.Mvc;
using ToDoList.Contracts;
using ToDoList.Entities;

namespace ToDoList.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserRepository _userRepository;

        public HomeController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IActionResult Index(int? id)
        {
            User user;
            if (id.HasValue)
            {
                user = _userRepository.FindById((int)id);
                return View(user);
            }
            return RedirectToAction("Login","User");
        }
    }
}