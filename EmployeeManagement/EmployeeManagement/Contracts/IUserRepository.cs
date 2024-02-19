using EmployeeManagement.Models;
using EmployeeManagement.ViewModels;

namespace EmployeeManagement.Contracts
{
    public interface IUserRepository
    {
        public Task<User> CreateUserAsync(User user);

        public Task<User?> UpdateUserAsync(UpdateUserViewModel updateUser, long userId);

        public Task<List<UserViewModel>> GetUsersAsync(bool enabled);
    }
}
