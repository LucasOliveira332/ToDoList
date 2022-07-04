using ToDoList.Entities;

namespace ToDoList.Contracts
{
    public interface ICardRepository
    {
        List<Card> FindAll(int id);
        void Add(string title, string description, int userId);
        void Add(string title, int userId);
    }
}
