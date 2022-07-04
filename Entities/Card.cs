using System.ComponentModel.DataAnnotations;

namespace ToDoList.Entities
{
    public class Card
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
    }
}
