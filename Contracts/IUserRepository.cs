using ToDoList.Entities;

namespace ToDoList.Contracts
{
    public interface IUserRepository
    {
        bool UserValidation(User user);
        User FindById(int id);
    }
}
