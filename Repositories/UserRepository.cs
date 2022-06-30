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

            using (_session.Connection)
            {
                user = _session.Connection.QueryFirstOrDefault<User>(query,paranmeters);
            }

            return user;
        }
        public bool UserValidation(User user)
        {
            User validation;

            var query = "SELECT * FROM TbUser " +
                            "WHERE Email = @Email " +
                            "AND Password = @Password";

            var paranmeters = new {Email = user.Email, Password = user.Password};

            using (_session.Connection)
            {
               validation = _session.Connection.QueryFirstOrDefault<User>(query, paranmeters);
            }

            user.Id = validation.Id;

            if(validation == null)
            {
                return false;
            }

            return true;
        }
    }
}
