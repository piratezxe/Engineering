using System;
using System.Threading;
using System.Threading.Tasks;
using EngineeringWork.Core.Interface.Repositories;
using EngineeringWork.Core.Interface.Services.Password;
using MediatR;

namespace EngineeringWork.Web.Domain.Users.ChangeUserPassword
{
    public class ChangeUserPasswordCommandHandler : IRequestHandler<ChangeUserPasswordCommand>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordService _passwordService;
        public ChangeUserPasswordCommandHandler(IUserRepository userRepository, IPasswordService passwordService)
        {
            _userRepository = userRepository;
            _passwordService = passwordService;
        }

        public async Task<Unit> Handle(ChangeUserPasswordCommand request, CancellationToken cancellationToken)
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
