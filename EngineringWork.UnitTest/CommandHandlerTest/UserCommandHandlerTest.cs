using System;
using System.Threading;
using System.Threading.Tasks;
using EngineeringWork.Core.Interface.Repositories;
using EngineeringWork.Core.Interface.Services.Password;
using EngineeringWork.Infrastructure.CommandHandlers.Users;
using EngineeringWork.Infrastructure.Commands.Users;
using FluentAssertions;
using Moq;
using Xunit;

namespace EngineringWork.UnitTest.CommandHandlerTest
{
    public class UnitTest1
    {
        [Fact]
        public async Task register_user_handler_should_not_be_null()
        {
            var userRepositoryMock = new Mock<IUserRepository>();
            var passwordService = new Mock<IPasswordService>();
            passwordService.Setup(x => x.HashPassword(It.IsAny<string>())).Returns("asdasd");
            var createUserHandler = new CreateUserHandler(userRepositoryMock.Object, passwordService.Object);

            var result = await createUserHandler.Handle(new CreateUser()
            {
                Email = "asdasdasd",
                Password = "asdasd", 
                Username = "asdasdasd"
            }, new CancellationToken());

            result.Should().NotBeNull();
        }

        [Fact]
        public async Task change_user_handler_should_not_be_null()
        {
            var userRepositoryMock = new Mock<IUserRepository>();
            var passwordService = new Mock<IPasswordService>();
            var userHandler = new ChangeUserPasswordHandler(userRepositoryMock.Object, passwordService.Object);
            
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
            
            var result = await userHandler.Handle(new ChangeUserPassword()
            {
            CurrentPassword = "asasdasd",
            NewPassword = "asasdasd"
            }, new CancellationToken());

            result.Should().NotBeNull();
        }
    }
}
