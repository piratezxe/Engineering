using System.Threading;
using System.Threading.Tasks;
using EngineeringWork.Core.Interface.Services.JwtTokenService;
using EngineeringWork.Infrastructure.Commands.Accounts;
using EngineeringWork.Infrastructure.Services.JwtTokenService;
using MediatR;

namespace EngineeringWork.Infrastructure.CommandHandlers.AccountsHandler
{
    public class RevokeAcessTokenHandler : IRequestHandler<RevokeAcessTokenCommand>
    {
        private readonly ITokenManager _tokenManager;

        public RevokeAcessTokenHandler(ITokenManager tokenManager)
        {
            _tokenManager = tokenManager;
        }

        public async Task<Unit> Handle(RevokeAcessTokenCommand notification, CancellationToken cancellationToken)
        {
            await _tokenManager.RevokeRefreshTokenAsync(notification.Token);
            return  Unit.Value;
        }
    }
}