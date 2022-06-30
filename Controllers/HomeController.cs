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

        [HttpGet]
        public IActionResult Index(int? id)
        {
            if(id.HasValue)
            {
                User user = _userRepository.FindById((int)id);
                
                if(user == null)
                {
                    return RedirectToAction("Login", "User");
                }

                return View(user);
            }
            return RedirectToAction("Login", "User");
        }
    }
}