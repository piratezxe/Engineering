using System;
using System.Threading.Tasks;
using Passenger.Core.Repositories;
using Passenger.Infrastructure.DTO;

namespace Passenger.Infrastructure.Services.JwtTokenService
{
    public class TokenManager : ITokenManager
    {
        private readonly ITokenRepository _tokenRepository;

        private readonly IJwtHandler _jwtHandler;

        private readonly IUserRepository _userRepository;

        public TokenManager(ITokenRepository tokenRepository, IJwtHandler jwtHandler, IUserRepository userRepository)
        {
            _tokenRepository = tokenRepository;
            _jwtHandler = jwtHandler;
            _userRepository = userRepository;
        }

        public async Task RevokeRefreshTokenAsync(string token)
        {
            var _token = await _tokenRepository.GetTokneAsync(token);
            if(_token is null)
                throw new Exception($"RefreshToken not exist");

            if(_token.Revoke)
                throw new ArithmeticException("Toke is already revoked");
            
            _token.Revoke = true;
        }

        public async Task<JwtDto> RefreshAcessTokenAsync(string token)
        {
            var refreshToken = await _tokenRepository.GetTokneAsync(token);
            if(refreshToken is null)
                throw new ArgumentException("Token not exist");
            
            if(refreshToken.Revoke)
                throw new ArithmeticException("Token is already revoked");

            var email = refreshToken.UserEmail;
            var user = await _userRepository.GetAsyncByEmail(email);
            if(user is null)
                throw new ArgumentException($"User with {email} not exist");
            
            var acessToken = _jwtHandler.CreateToken(email, user.Role);
            acessToken.RefreshToken = refreshToken;
            return acessToken;
        }
    }
}