using ToDoList.Entities;

namespace ToDoList.Contracts
{
    public interface ICardRepository
    {
        List<Card> FindAll(int id);
        void Add(string title, string description, DateTime date, int userId);
        void Add(string title, DateTime date, int userId);

        void Remove(int id);
    }
}
