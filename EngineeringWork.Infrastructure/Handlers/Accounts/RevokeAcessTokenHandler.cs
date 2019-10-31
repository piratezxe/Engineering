using System.Threading.Tasks;
using EngineeringWork.Infrastructure.Commands;
using EngineeringWork.Infrastructure.Commands.Accounts;
using EngineeringWork.Infrastructure.Services.JwtTokenService;

namespace EngineeringWork.Infrastructure.Handlers.Accounts
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