using EmployeeManagement.Contracts;
using EmployeeManagement.Data;
using EmployeeManagement.Models;
using EmployeeManagement.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Repositories
{
    public class UsersRepository : IUserRepository
    {
        private readonly ManagementDbContext _context;

        public UsersRepository(ManagementDbContext context)
        {
            _context = context;
        }

        public async Task<User> CreateUserAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<User?> UpdateUserAsync(UpdateUserViewModel updateUser, long userId)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.UserId == userId);

            if (user == null)
                return null;

            if (!string.IsNullOrWhiteSpace(updateUser.Password))
                user.Password = updateUser.Password;

            user.Enabled = updateUser.Enabled;

            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<List<UserViewModel>> GetUsersAsync(bool enabled)
        {
            var users = await _context.Users.Where(x => x.Enabled == enabled).ToListAsync();

            var usersViewModel = new List<UserViewModel>();
            foreach (var user in users)
            {
                var userView = new UserViewModel()
                {
                    Login = user.Login,
                    Enabled = user.Enabled,
                };

                usersViewModel.Add(userView);
            }

            return usersViewModel;
        }

    }
}
