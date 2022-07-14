using ToDoList.Entities;

namespace ToDoList.Contracts
{
    public interface IUserRepository
    {
        Task<User> UserValidation(User user);
    }
}
