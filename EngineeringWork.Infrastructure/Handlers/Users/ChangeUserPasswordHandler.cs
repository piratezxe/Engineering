using System;
using System.Threading.Tasks;
using EngineeringWork.Infrastructure.Commands;
using EngineeringWork.Infrastructure.Commands.Users;
using EngineeringWork.Infrastructure.Services.UserService;

namespace EngineeringWork.Infrastructure.Handlers.Users
{
    public class ChangeUserPasswordHandler : ICommandHandler<ChangeUserPassword>
    {
        private readonly IUserService _userService;

        public ChangeUserPasswordHandler(IUserService userService)
        {
            _userService = userService;
        }

        public Task HandleAsync(ChangeUserPassword command)
        {
            throw new NotImplementedException();
//            await _userService.ChangePasswordAsync(command.CurrentPassword, command.NewPassword);
        }
    }
}