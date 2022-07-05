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
                            "Where IdUser = @Id Order by DateTime";

            var parameters = new { Id = id };

            var dbResult = _session.Connection.Query(query, parameters).ToList();

            foreach(var item in dbResult)
            {
                cards.Add(new() { Title = item.Title, Description = item.Description, Date = item.DateTime});
            }
            
            return cards;
        }

        public void Add(string title, DateTime date, int userId)
        {
            var query = "INSERT INTO TbCard(title, DateTime, IdUser) " +
                            "VALUES(@Title, @Date, @UserId)";

            var parameters = new { Title = title, Date = date.ToString("yyyy-MM-dd"), UserId = userId };
           _session.Connection.Query(query, parameters);
        }

        public void Add(string title, string description, DateTime date, int userId)
        {
            var query = "INSERT INTO TbCard " +
                            "VALUES(@Title, @Description, @Date, @UserId)";

            var parameters = new { Title = title, Description = description, Date = date.ToString("yyyy-MM-dd"), UserId = userId };

            _session.Connection.Query(query, parameters);
        }
    }
}

