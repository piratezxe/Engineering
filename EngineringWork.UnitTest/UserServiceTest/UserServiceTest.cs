using System;
using System.Threading.Tasks;
using AutoMapper;
using Moq;
using Passenger.Core.Domain;
using Passenger.Core.Repositories;
using Passenger.Infrastructure.Services;
using Xunit;
using Xunit.Sdk;

namespace EngineringWork.UnitTest.UserServiceTest
{
    public class UnitTest1
    {
        [Fact]
        public async Task register_async_should_add_user_to_repository()
        {
            var userRepositoryMock = new Mock<IUserRepository>();
            var encrypterMock = new Mock<IEncrypter>();
            var mapperMock = new Mock<IMapper>();

            encrypterMock.Setup(x => x.GetSalt(It.IsAny<string>())).Returns("salt");
            encrypterMock.Setup(x => x.GetHash(It.IsAny<string>(), It.IsAny<string>())).Returns("hash");
            
            var userService =  new UserService(userRepositoryMock.Object, encrypterMock.Object, mapperMock.Object);
            await userService.RegisterAsync(Guid.NewGuid(), "email@gmail.com", "username", "secret", "user");
            
            userRepositoryMock.Verify(x => x.AddAsync(It.IsAny<User>()), Times.Once);
        }

        [Fact]
        public async Task when_calling_get_user_and_it_exist_it_should_calling_userRepository_async()
        {
            var userRepositoryMock = new Mock<IUserRepository>();
            var encrypterMock = new Mock<IEncrypter>();
            var mapperMock = new Mock<IMapper>();

//            encrypterMock.Setup(x => x.GetSalt(It.IsAny<string>())).Returns("salt");
//            encrypterMock.Setup(x => x.GetHash(It.IsAny<string>(), It.IsAny<string>())).Returns("hash");
            
            var userService =  new UserService(userRepositoryMock.Object, encrypterMock.Object, mapperMock.Object);

            var user = new User(Guid.NewGuid(),"karol@gmail.com", "asdasd", "User", "hash", "salt");

            userRepositoryMock.Setup(x => x.GetAsyncByEmail(It.IsAny<string>())).ReturnsAsync(user);

            await userService.GetAsync("karol@gmail.com");

            userRepositoryMock.Verify(x => x.GetAsyncByEmail(It.IsAny<string>()), Times.Once);
        }
        
        [Fact]
        public async Task when_calling_get_user_and_it_not_exist_it_should_calling_user_repository_async()
        {
            var userRepositoryMock = new Mock<IUserRepository>();
            var encrypterMock = new Mock<IEncrypter>();
            var mapperMock = new Mock<IMapper>();

            var userService = new UserService(userRepositoryMock.Object, encrypterMock.Object, mapperMock.Object);
            await userService.GetAsync("karo@gmaik.com");
            
            userRepositoryMock.Setup(x => x.GetAsyncByEmail(It.IsAny<string>())).ReturnsAsync(() => null);
            
            userRepositoryMock.Verify(x => x.GetAsyncByEmail(It.IsAny<string>()), Times.Once);
        }


    }
}