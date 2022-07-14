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

        public async Task<User> UserValidation(User user)
        {
            User validation;

            var query = "SELECT * FROM TbUser " +
                            "WHERE Email = @Email " +
                            "AND Password = @Password";

            var paranmeters = new {Email = user.Email.ToLower()!, Password = user.Password };

           
            validation = await _session.Connection.QueryFirstOrDefaultAsync<User>(query, paranmeters);
            return validation;
        }
    }
}
