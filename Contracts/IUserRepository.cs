using ToDoList.Entities;

namespace ToDoList.Contracts
{
    public interface IUserRepository
    {
        User UserValidation(User user);
        User FindById(int id);
    }
}
