using Microsoft.AspNetCore.Mvc;
using ToDoList.Contracts;
using ToDoList.Entities;
using ToDoList.Models;

namespace ToDoList.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICardRepository _cardRepository;

        public HomeController(IUserRepository userRepository, ICardRepository cardRepository)
        {
            _cardRepository = cardRepository;
        }

        [HttpGet]
        public IActionResult Index(User user)
        {
            if(user == null)
            {
                return RedirectToAction("Login", "User");
            }

            List<Card> cards = _cardRepository.FindAll(user.Id);

            CardViewModel cardViewModel = new() { Cards = cards, User = user };

            return View(cardViewModel);
        }
    }
}