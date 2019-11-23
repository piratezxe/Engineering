using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using EngineeringWork.Core.Domain;
using EngineeringWork.Core.Interface.Repositories;
using EngineeringWork.Infrastructure.Query.UserQuery;
using EngineeringWork.Infrastructure.QueryHandlers.UserHandler;
using FluentAssertions;
using Moq;
using Xunit;

namespace EngineringWork.UnitTest.QueryHandlerTest
{
    public class UserQueryHandlerTest
    {
        [Fact]
        public async Task call_get_all_user_handler_should_not_return_null()
        {
            var userRepositoryMock = new Mock<IUserRepository>();
            var mapperMock = new Mock<IMapper>();
            var userQueryHandler = new GetUserQueryHandler(userRepositoryMock.Object, mapperMock.Object);

             userRepositoryMock.Setup(x => x.GetAllAsync()).ReturnsAsync(new List<User>());

            var result = await userQueryHandler.Handle(new GetAllUserQuery(), CancellationToken.None);
            result.Should().NotBeNull();
        }
        
        [Fact]
        public async Task call_get_user_by_id_handler_should_not_return_null()
        {
            var userRepositoryMock = new Mock<IUserRepository>();
            var mapperMock = new Mock<IMapper>();
            var userQueryHandler = new GetUserQueryHandler(userRepositoryMock.Object, mapperMock.Object);

            userRepositoryMock.Setup(x => x.GetAsync(It.IsAny<Guid>())).ReturnsAsync(new User());
            
            var result =  await userQueryHandler.Handle(new GetUserQuery() { Id = Guid.NewGuid() }, CancellationToken.None);
            result.Should().NotBeNull();
        }
    }
}