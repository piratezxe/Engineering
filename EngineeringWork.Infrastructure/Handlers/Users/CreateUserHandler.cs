using System;
using System.Threading.Tasks;
using EngineeringWork.Infrastructure.Commands;
using EngineeringWork.Infrastructure.Commands.Users;
using EngineeringWork.Infrastructure.Services.UserService;

namespace EngineeringWork.Infrastructure.Handlers.Users
{
    public class CreateUserHandler : ICommandHandler<CreateUser>
    {
        private readonly IUserService _userService;
        
        public CreateUserHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task HandleAsync(CreateUser command)
        {
            await _userService.RegisterAsync(Guid.NewGuid() , command.Email, command.Username, command.Password, command.Role);
        }
    }
}