using System.Threading;
using System.Threading.Tasks;
using EngineeringWork.Infrastructure.Application.Users.CreateUser;
using EngineeringWork.Infrastructure.Services.Password;
using EngineeringWork.Repository.Repositories.Interface;
using FluentAssertions;
using Moq;
using Xunit;

namespace EngineringWork.UnitTest.UserTest
{
    public class CreateUserCommandHandlerTest
    {
        [Fact]
        public async Task register_user_handler_should_not_be_null()
        {
            var userRepositoryMock = new Mock<IUserRepository>();
            var passwordService = new Mock<IPasswordService>();
            passwordService.Setup(x => x.HashPassword(It.IsAny<string>())).Returns("asdasd");
            var createUserHandler = new CreateUserHandler(userRepositoryMock.Object, passwordService.Object);

            var result = await createUserHandler.Handle(new CreateUserCommand()
            {
                Email = "asdasdasd",
                Password = "asdasd", 
                Username = "asdasdasd"
            }, new CancellationToken());

            result.Should().NotBeNull();
        }
    }
}
