using Prisma_studio.DTOs.User;
using Prisma_studio.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prisma_studio.Services.Interfaces
{
    public interface IUserService : IValidateModel
    {
        public Task<bool> AuthenticateUserAsync(string username, string password);
        public Task RegisterUserAsync(RegisterUserInputModel registrationModel);
        public Task<bool> UpdateUserAsync(EditProfileInputModel user);
        public User? GetLoggedInUserAsync();
        public Task<User?> FindUserByIdAsync(Guid userId);
        public Task<bool> DeleteUserAsync(Guid userId);
        public void LogoutUser();
        Task<bool> IsUserAdminAsync(Guid userId);
        public Task<bool> IsUsernameTaken(string username);
        public Task<IEnumerable<UserDataViewModel>> GetUsersAsync();
        public Task<bool> MakeUserAdminAsync(Guid userId);
        public Task<bool> RemoveAdminRoleAsync(Guid userId);

    }
}
