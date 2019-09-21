using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using Passenger.Core.Repositories;
using Passenger.Infrastructure.Commands;
using Passenger.Infrastructure.Commands.Accounts;
using Passenger.Infrastructure.Extensions;
using Passenger.Infrastructure.Services;
using Passenger.Infrastructure.Services.JwtTokenService;

namespace Passenger.Infrastructure.Handlers.Accounts
{
    public class LoginHandler : ICommandHandler<Login>
    {
        private readonly IUserService _userService;
        private readonly IJwtHandler _jwtHandler;
        private readonly IMemoryCache _cache;
        private readonly ITokenRepository _tokenRepository;
        public LoginHandler(IUserService userService, IJwtHandler jwtHandler,
            IMemoryCache cache, ITokenRepository tokenRepository)
        {    
            _userService = userService;
            _jwtHandler = jwtHandler;
            _cache = cache;
            _tokenRepository = tokenRepository;
        }

        public async Task HandleAsync(Login command)
        {
            await _userService.LoginAsync(command.Email, command.Password);
            var user = await _userService.GetAsync(command.Email);
            var jwt = _jwtHandler.CreateToken(user.Id, user.Role);
            var refreshToken = _jwtHandler.CreateRefreshToken(user.Role, user.Id);
            jwt.RefreshToken = refreshToken;
            await _tokenRepository.CreateAsync(refreshToken);
            _cache.SetJwt(command.Email, jwt);
        }        
    }
}