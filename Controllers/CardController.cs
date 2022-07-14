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
        public IActionResult Add(string title, string description, DateTime date, User user)
        {

            if (description == null)
            {
                _cardRepository.Add(title, date, user.Id);
                return RedirectToAction("Index", "Home");
            }
            _cardRepository.Add(title, description, date, user.Id);
            return RedirectToAction("Index", "Home");

        }

        [HttpPost]
        public IActionResult Remove(string id)
        {
            var CardId = int.Parse(id);
            _cardRepository.Remove(CardId);

            return RedirectToAction("Index", "Home");
        }


    }
}
