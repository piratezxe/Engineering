using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Passenger.Core.Domain;
using Passenger.Core.Repositories;
using Passenger.Infrastructure.DTO;
using Passenger.Infrastructure.Services.Password;

namespace Passenger.Infrastructure.Services.UserService
{
    public class UserService : IUserService
    { 
        private readonly IUserRepository _userRepository;
        private readonly IPasswordService _passwordService;
        private readonly IMapper _mapper;
        

        public UserService(IUserRepository userRepository, IMapper mapper, IPasswordService passwordService)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _passwordService = passwordService;
        }

        public async Task<UserDto> GetAsync(string email)
        {
            var user = await _userRepository.GetAsyncByEmail(email);

            return _mapper.Map<User,UserDto>(user);
        }

        public async Task<UserDto> GetAsyncById(Guid userId)
        {
            var user = await _userRepository.GetAsync(userId);

            return _mapper.Map<User,UserDto>(user);
        }

        public async Task<IEnumerable<UserDto>> GetAllAsync()
        {
            var users = await _userRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<User>, IEnumerable<UserDto>>(users);
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

        public async Task ChangePasswordAsync(string password, string newPassword, Guid userId)
        {
            var user = await _userRepository.GetAsync(userId);
            if(user is null)
                throw new ArgumentException($"User with Id: {userId} not exist");

            var hash = _passwordService.HashPassword(password);
            user.SetPassword(hash);
        }

        public async Task RegisterAsync(Guid userId, string email, string username, string password, string role)
        {
            var user = await _userRepository.GetAsyncByEmail(email);
            if(user != null)
            {
                throw new Exception($"User with email: '{email}' already exists.");
            }

            var hash = _passwordService.HashPassword(password);
            user = new User(userId, email, username, role, hash);
            await _userRepository.AddAsync(user);
        }
    }
}