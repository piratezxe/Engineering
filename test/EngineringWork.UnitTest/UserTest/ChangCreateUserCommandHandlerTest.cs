using System;
using System.Threading;
using System.Threading.Tasks;
using EngineeringWork.Infrastructure.Application.Users.ChangeUserPassword;
using EngineeringWork.Infrastructure.Services.Password;
using EngineeringWork.Repository.Repositories.Interface;
using FluentAssertions;
using Moq;
using Xunit;

namespace EngineringWork.UnitTest.UserTest
{
    public  class ChangCreateUserCommandHandlerTest
    {
        [Fact]
        public async Task change_user_handler_should_not_be_null()
        {
            var userRepositoryMock = new Mock<IUserRepository>();
            var passwordService = new Mock<IPasswordService>();
            var userHandler = new ChangeUserPasswordCommandHandler(userRepositoryMock.Object, passwordService.Object);
            
            passwordService.Setup(x => x.HashPassword(It.IsAny<string>())).Returns("asdasd");
            userRepositoryMock.Setup(x => x.GetAsync(It.IsAny<Guid>())).ReturnsAsync( 
                new EngineeringWork.Core.Domain.User(
                    new Guid(), 
                    "asdasd", 
                    "aasdasd" ,
                    "user", 
                    "asdasdasdasdasd" 
                ) 
            );
            
            var result = await userHandler.Handle(new ChangeUserPasswordCommand()
            {
                CurrentPassword = "asasdasd",
                NewPassword = "asasdasd"
            }, new CancellationToken());

            result.Should().NotBeNull();
        }
    }
}