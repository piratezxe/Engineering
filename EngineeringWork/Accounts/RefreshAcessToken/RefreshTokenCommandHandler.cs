using System.Threading;
using System.Threading.Tasks;
using EngineeringWork.Core.Interface.Services.JwtTokenService;
using EngineeringWork.Infrastructure.Commands.Accounts;
using MediatR;
using Microsoft.Extensions.Caching.Memory;

namespace EngineeringWork.Infrastructure.CommandHandlers.AccountsHandler
{
    public class RefreshAcessTokenHandler : IRequestHandler<RefreshAcessTokenCommand>
    {
        private readonly ITokenManager _tokenManager;

        private readonly IMemoryCache _memoryCache;

        public RefreshAcessTokenHandler(ITokenManager tokenManager, IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
            _tokenManager = tokenManager;
        }

        public async Task<Unit> Handle(RefreshAcessTokenCommand notification, CancellationToken cancellationToken)
        {
            var token = await _tokenManager.RefreshAcessTokenAsync(notification.token);
            _memoryCache.Set(notification.Email, token);
            return  Unit.Value;
        }
    }
}