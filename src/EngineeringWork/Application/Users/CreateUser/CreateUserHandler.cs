using System;
using System.Threading;
using System.Threading.Tasks;
using EngineeringWork.Core.Domain;
using EngineeringWork.Core.Interface.Repositories;
using EngineeringWork.Core.Interface.Services.Password;
using MediatR;

namespace EngineeringWork.Web.Application.Users.CreateUser
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand>
    {
        private readonly IPasswordService _passwordService;

        private readonly IUserRepository _userRepository;
        
        public CreateUserHandler(IUserRepository userRepository, IPasswordService passwordService)
        {
            _userRepository = userRepository;
            _passwordService = passwordService;
        }

        public async Task<Unit> Handle(CreateUserCommand notification, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetAsyncByEmail(notification.Email);
            if(user != null)
            {
                throw new Exception($"User with email: '{notification.Email}' already exists.");
            }

            var hash = _passwordService.HashPassword(notification.Password);
            user = new User(notification.UserId, notification.Email, notification.Username , "user", hash);
            await _userRepository.AddAsync(user);            
            return Unit.Value;
        }
    }
}