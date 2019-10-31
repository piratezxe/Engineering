using System;
using System.Threading.Tasks;
using AutoMapper;
using EngineeringWork.Core.Domain;
using EngineeringWork.Core.Repositories;
using EngineeringWork.Infrastructure.Services.Password;
using EngineeringWork.Infrastructure.Services.UserService;
using Moq;
using Xunit;

namespace EngineringWork.UnitTest.ServiceTest.UserTest
{
    public class UnitTest1
    {
        [Fact]
        public async Task register_async_should_add_user_to_repository()
        {
            var userRepositoryMock = new Mock<IUserRepository>();
            var passwordServiceMock = new Mock<IPasswordService>();
            var mapperMock = new Mock<IMapper>();

            passwordServiceMock.Setup(x => x.HashPassword(It.IsAny<string>())).Returns("hash");
            
            userRepositoryMock.Verify(x => x.AddAsync(It.IsAny<User>()), Times.Once);
        }

        [Fact]
        public async Task when_calling_get_user_and_it_exist_it_should_calling_userRepository_async()
        {
            var userRepositoryMock = new Mock<IUserRepository>();
            var encrypterMock = new Mock<IPasswordService>();
            var mapperMock = new Mock<IMapper>();

            var userService =  new UserService(userRepositoryMock.Object, mapperMock.Object, encrypterMock.Object);

            var user = new User(Guid.NewGuid(),"karol@gmail.com", "asdasd", "User", "hash");

            userRepositoryMock.Setup(x => x.GetAsyncByEmail(It.IsAny<string>())).ReturnsAsync(user);

            await userService.GetAsync("karol@gmail.com");

            userRepositoryMock.Verify(x => x.GetAsyncByEmail(It.IsAny<string>()), Times.Once);
        }
        
        [Fact]
        public async Task when_calling_get_user_and_it_not_exist_it_should_calling_user_repository_async()
        {
            var userRepositoryMock = new Mock<IUserRepository>();
            var encrypterMock = new Mock<IPasswordService>();
            var mapperMock = new Mock<IMapper>();

            var userService = new UserService(userRepositoryMock.Object, mapperMock.Object,  encrypterMock.Object);
            await userService.GetAsync("karo@gmaik.com");
            
            userRepositoryMock.Setup(x => x.GetAsyncByEmail(It.IsAny<string>())).ReturnsAsync(() => null);
            
            userRepositoryMock.Verify(x => x.GetAsyncByEmail(It.IsAny<string>()), Times.Once);
        }


    }
}
