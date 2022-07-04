using Microsoft.AspNetCore.Mvc;
using ToDoList.Contracts;
using ToDoList.Entities;

namespace ToDoList.Controllers
{
    public class CardController : Controller
    {
        
        private readonly ICardRepository _cardRepository;

        public CardController(ICardRepository cardRepository)
        {
            _cardRepository = cardRepository;
        }

        [HttpPost]
        public IActionResult Index(string title, string description, int id)
        {
            _cardRepository.Add(title, description, id);
            return RedirectToAction("Index","Home");
        }
    }
}
