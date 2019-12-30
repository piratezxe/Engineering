using System.Threading;
using System.Threading.Tasks;
using EngineeringWork.Infrastructure.Extensions;
using EngineeringWork.Infrastructure.Services.JwtTokenService;
using EngineeringWork.Infrastructure.Services.UserService;
using EngineeringWork.Repository.Repositories.Interface;
using MediatR;
using Microsoft.Extensions.Caching.Memory;

namespace EngineeringWork.Infrastructure.Application.Accounts.LoginUser
{
    public class LoginUserHandler :  IRequestHandler<LoginUserCommand>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserService _userService;
        private readonly IJwtHandler _jwtHandler;
        private readonly IMemoryCache _cache;
        private readonly ITokenRepository _tokenRepository;
        
        public LoginUserHandler(IJwtHandler jwtHandler,
            IMemoryCache cache, ITokenRepository tokenRepository, IUserService userService, IUserRepository userRepository)
        {    
            _jwtHandler = jwtHandler;
            _cache = cache;
            _tokenRepository = tokenRepository;
            _userService = userService;
            _userRepository = userRepository;
        }

        public async Task<Unit> Handle(LoginUserCommand notification, CancellationToken cancellationToken)
        {
            await _userService.LoginAsync(notification.Email, notification.Password);
            var user = await _userRepository.GetAsyncByEmail(notification.Email);
            var jwt = _jwtHandler.CreateToken(user.Id, user.Role);
            var refreshToken = _jwtHandler.CreateRefreshToken(user.Role, user.Id);
            jwt.RefreshToken = refreshToken;
            await _tokenRepository.CreateAsync(refreshToken);
            _cache.SetJwt(notification.Email, jwt);      
            return Unit.Value;
        }
    }
}