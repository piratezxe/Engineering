using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EngineeringWork.Infrastructure.DTO;

namespace EngineeringWork.Infrastructure.Services.UserService
{
    public interface IUserService : IService
    {
        Task<UserDto> GetAsync(string email);
        Task<UserDto> GetAsyncById(Guid userId);
        Task<IEnumerable<UserDto>> GetAllAsync();
        Task RegisterAsync(Guid userId, string email, string username, string password, string role);
        Task LoginAsync(string email, string password);
        Task ChangePasswordAsync(string password, string newPassword, Guid userId);
    }
}