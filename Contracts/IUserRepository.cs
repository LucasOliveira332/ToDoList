using ToDoList.Entities;

namespace ToDoList.Contracts
{
    public interface IUserRepository
    {
        User UserValidation(string email, string password);
        User FindById(int id);
    }
}
