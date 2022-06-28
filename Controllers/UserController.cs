using Microsoft.AspNetCore.Mvc;

namespace ToDoList.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
