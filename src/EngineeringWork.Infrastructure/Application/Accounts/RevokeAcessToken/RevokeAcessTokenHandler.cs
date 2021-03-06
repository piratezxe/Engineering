using System.Threading;
using System.Threading.Tasks;
using EngineeringWork.Infrastructure.Services.JwtTokenService;
using MediatR;

namespace EngineeringWork.Infrastructure.Application.Accounts.RevokeAcessToken
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