using ToDoList.Entities;

namespace ToDoList.Models
{
    public class CardViewModel
    {
        public IEnumerable<Card> Card { get; set; }
        public User User { get; set; }
    }
}
