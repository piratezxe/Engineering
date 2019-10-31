using System.Threading.Tasks;
using EngineeringWork.Infrastructure.Commands;
using EngineeringWork.Infrastructure.Commands.Accounts;
using EngineeringWork.Infrastructure.Services.JwtTokenService;
using Microsoft.Extensions.Caching.Memory;

namespace EngineeringWork.Infrastructure.Handlers.Accounts
{
    public class RefreshAcessTokenHandler : ICommandHandler<ResfreshAcessToken>
    {
        private readonly ITokenManager _tokenManager;

        private readonly IMemoryCache _memoryCache;

        public RefreshAcessTokenHandler(ITokenManager tokenManager, IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
            _tokenManager = tokenManager;
        }

        public async Task HandleAsync(ResfreshAcessToken command)
        {
            var token = await _tokenManager.RefreshAcessTokenAsync(command.token);
            _memoryCache.Set(command.Email, token);
        }
    }
}