using Microsoft.AspNetCore.Mvc;
using ToDoList.Contracts;
using ToDoList.Entities;
using ToDoList.Models;

namespace ToDoList.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly ICardRepository _cardRepository;

        public HomeController(IUserRepository userRepository, ICardRepository cardRepository)
        {
            _userRepository = userRepository;
            _cardRepository = cardRepository;
        }

        [HttpGet]
        public IActionResult Index(int UserId)
        {
            User user = _userRepository.FindById(UserId);

            if (user == null)
            {
                return RedirectToAction("Login", "User");
            }

            List<Card> cards = _cardRepository.FindAll(UserId);

            var cardViewModel = new { Card = cards, User = user };

            return View(cardViewModel);
        }
    }
}