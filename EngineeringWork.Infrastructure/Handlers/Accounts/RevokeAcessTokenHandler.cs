using System.Threading.Tasks;
using Passenger.Infrastructure.Commands;
using Passenger.Infrastructure.Commands.Accounts;
using Passenger.Infrastructure.Services.JwtTokenService;

namespace Passenger.Infrastructure.Handlers.Accounts
{
    public class RevokeAcessTokenHandler : ICommandHandler<RevokeAcessToken>
    {
        private readonly ITokenManager _tokenManager;

        public RevokeAcessTokenHandler(ITokenManager tokenManager)
        {
            _tokenManager = tokenManager;
        }

        public async Task HandleAsync(RevokeAcessToken command)
        {
            await _tokenManager.RevokeRefreshTokenAsync(command.Token);
        }
    }
}