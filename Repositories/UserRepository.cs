using ToDoList.Contracts;
using ToDoList.Entities;
using ToDoList.Data;
using Dapper;

namespace ToDoList.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DbSession _session;

        public UserRepository(DbSession session)
        {
            _session = session;
        }

        public User FindById(int id)
        {
            User user;
            var query = "SELECT * FROM TbUser " +
                            "WHERE Id = @Id";

            var paranmeters = new { Id = id };

            user = _session.Connection.QueryFirstOrDefault<User>(query,paranmeters);
            return user;
        }
        public User UserValidation(string email, string password)
        {
            User validation;

            var query = "SELECT * FROM TbUser " +
                            "WHERE Email = @Email " +
                            "AND Password = @Password";

            var paranmeters = new {Email = email, Password = password };

           
            validation = _session.Connection.QueryFirstOrDefault<User>(query, paranmeters);
            return validation;
        }
    }
}
