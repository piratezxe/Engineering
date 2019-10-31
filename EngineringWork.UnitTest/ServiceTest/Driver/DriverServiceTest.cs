using System;
using System.Threading.Tasks;
using AutoMapper;
using EngineeringWork.Core.Repositories;
using EngineeringWork.Infrastructure.Services.DriverService;
using Moq;
using Xunit;

namespace EngineringWork.UnitTest.ServiceTest.Driver
{
    public class DriverServiceTest
    {
        [Fact]
        public async Task when_create_driver_should_add_driver_to_repository_async()
        {
            var driverRepsitoryMock = new Mock<IDriverRepository>();
            var mapperMock = new Mock<IMapper>();
            
            var driverSerivce = new DriverService(driverRepsitoryMock.Object, mapperMock.Object);
            await driverSerivce.CreateAsync(Guid.NewGuid());
            
            driverRepsitoryMock.Verify(x => x.AddAsync(It.IsAny<EngineeringWork.Core.Domain.Driver>()), Times.Once);
        }

        [Fact]
        public async Task when_calling_driver_and_it_exist_should_invoke_repository_async()
        {
            var driverRepository = new Mock<IDriverRepository>();
            var maper = new Mock<IMapper>();
            
            var driverService = new DriverService(driverRepository.Object, maper.Object);
            var driver = new EngineeringWork.Core.Domain.Driver(Guid.NewGuid());
            driverRepository.Setup(x => x.GetAsync(It.IsAny<Guid>())).ReturnsAsync(driver);

            await driverService.GetAsync(Guid.Empty);

            driverRepository.Verify(x => x.GetAsync(It.IsAny<Guid>()), Times.Once);
        }
        
    }
}