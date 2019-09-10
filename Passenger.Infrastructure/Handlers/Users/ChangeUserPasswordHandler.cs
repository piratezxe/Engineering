using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Passenger.Infrastructure.Commands;
using Passenger.Infrastructure.Commands.Users;
using Passenger.Infrastructure.Services;

namespace Passenger.Infrastructure.Handlers.Users
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