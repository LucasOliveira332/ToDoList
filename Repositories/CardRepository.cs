using Dapper;
using ToDoList.Contracts;
using ToDoList.Data;
using ToDoList.Entities;

namespace ToDoList.Repositories
{
    public class CardRepository : ICardRepository
    {
        private readonly DbSession _session;

        public CardRepository(DbSession session)
        {
            _session = session;
        }

        public List<Card> FindAll(int id)
        {
            List<Card> cards = new();
            var query = "SELECT Title, Description, DateTime " +
                            "FROM TbCard " +
                            "Where IdUser = @Id";

            var parameters = new { Id = id };

            var dbResult = _session.Connection.Query(query, parameters).ToList();

            foreach(var item in dbResult)
            {
                cards.Add(new() { Title = item.Title, Description = item.Description, Date = item.DateTime});
            }
            
            return cards;
        }

        public void Add(string title, int userId)
        {
            var query = "INSERT INTO TbCard " +
                            "VALUES('@Title', '@Description', @UserId)";

            var parameters = new { Title = title, UserId = userId };
           _session.Connection.Query(query, parameters);
        }

        public void Add(string title, string description, int userId)
        {
            var query = "INSERT INTO TbCard " +
                            "VALUES('@Title', '@description', @UserId)";

            var parameters = new { Title = title, Description = description, UserId = userId };

            _session.Connection.Query(query, parameters);
        }
    }
}

