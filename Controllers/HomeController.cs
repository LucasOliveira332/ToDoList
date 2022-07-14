using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using ToDoList.Contracts;
using ToDoList.Entities;
using ToDoList.Models;

namespace ToDoList.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ICardRepository _cardRepository;

        public HomeController(ICardRepository cardRepository)
        {
            _cardRepository = cardRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
                var id = User.FindFirst(ClaimTypes.Authentication).Value;
                List<Card> cards = _cardRepository.FindAll(int.Parse(id));

                CardViewModel cardViewModel = new() { Cards = cards, User = new() {Id = int.Parse(id)} };

                return View(cardViewModel);
        }
        

        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("login", "User");
        }
    }
}