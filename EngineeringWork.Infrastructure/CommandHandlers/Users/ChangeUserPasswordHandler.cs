using EngineeringWork.Core.Interface.Repositories;
using EngineeringWork.Core.Interface.Services.Password;
using EngineeringWork.Infrastructure.Commands.Users;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace EngineeringWork.Infrastructure.CommandHandlers.Users
{
    public class ChangeUserPasswordHandler : IRequestHandler<ChangeUserPassword>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordService _passwordService;
        public ChangeUserPasswordHandler(IUserRepository userRepository, IPasswordService passwordService)
        {
            _userRepository = userRepository;
            _passwordService = passwordService;
        }

        public async Task<Unit> Handle(ChangeUserPassword request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetAsync(request.UserId);
            if (user is null)
                throw new ArgumentException($"User with Id: {request.UserId} not exist");

            var hash = _passwordService.HashPassword(request.CurrentPassword);
            user.SetPassword(hash);
            return Unit.Value;
        }
    }
}
