using ToDoList.Entities;

namespace ToDoList.Models
{
    public class CardViewModel
    {
        public IEnumerable<Card> Cards { get; set; }
        public User User { get; set; }
        public Card Card { get; set; }
    }
}
