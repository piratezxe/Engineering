using System;
using System.Threading.Tasks;
using EngineeringWork.Infrastructure.Services.Password;
using EngineeringWork.Repository.Repositories.Interface;

namespace EngineeringWork.Infrastructure.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly IPasswordService _passwordService;
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository, IPasswordService passwordService)
        {
            _userRepository = userRepository;
            _passwordService = passwordService;
        }

        public async Task LoginAsync(string email, string password)
        {
            var user = await _userRepository.GetAsyncByEmail(email);
            if(user == null)
            {
                throw new Exception("User with email not exist");
            }

            var hash = _passwordService.HashPassword(password);
            if(_passwordService.VerifedPasswordHash(hash, password))
            {
                return;
            }
            throw new Exception("Invalid credentials");
        }
    }
}