using System;
using System.Threading.Tasks;
using Moq;
using Passenger.Core.Domain;
using Passenger.Core.Repositories;
using Passenger.Infrastructure.DTO;
using Passenger.Infrastructure.Services.JwtTokenService;
using Xunit;

namespace EngineringWork.UnitTest.ServiceTest.Refresh
{
    public class RefreshTokenServiceTest
    {

        [Fact]
        public async Task refresh_token_should_invoke_refresh_token_on_repository()
        {

            var tokenRepository = new Mock<ITokenRepository>();
            var userRepository = new Mock<IUserRepository>();
            var tokenHandler = new Mock<IJwtHandler>();
            
            var tokenService = new TokenManager(tokenRepository.Object, tokenHandler.Object, userRepository.Object);
            tokenHandler.Setup(x => x.CreateToken(It.IsAny<Guid>(), It.IsAny<string>())).Returns(new JwtDto());
            tokenRepository.Setup(x => x.GetTokneAsync(It.IsAny<string>())).ReturnsAsync(new RefreshToken());
            
            await tokenService.RefreshAcessTokenAsync("asdasdasd");
            
            
            tokenHandler.Verify(x => x.CreateToken(It.IsAny<Guid>(), It.IsAny<string>()), Times.Once);
        }
    }
}