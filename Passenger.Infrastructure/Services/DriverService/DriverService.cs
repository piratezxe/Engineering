using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Passenger.Core.Domain;
using Passenger.Core.Repositories;
using Passenger.Infrastructure.DTO;

namespace Passenger.Infrastructure.Services.DriverService
{
    public class DriverService : IDriverService
    {
        private readonly IDriverRepository _driverRepository;
        private readonly IMapper _mapper;

        public DriverService(IDriverRepository driverRepository, IMapper mapper)
        {
            _driverRepository = driverRepository;
            _mapper = mapper;
        }

        public async Task<DriverDto> GetAsync(Guid userId)
        {
            var driver = await _driverRepository.GetAsync(userId);
            
            return _mapper.Map<Driver,DriverDto>(driver);
        }

        public async Task CreateAsync(Guid userId)
        {
            var driver = await _driverRepository.GetAsync(userId);
            if(driver !=  null)
                throw new ArgumentException($"Driver with Id: {userId} actual exist");

            var _driver = new Driver(userId);
            await _driverRepository.AddAsync(_driver);
        }

        public async Task<IEnumerable<DriverDto>> BrowseAsync()
        {
            var drivers = await _driverRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<Driver>, IEnumerable<DriverDto>>(drivers);
        }

        public async Task SetVehickle(Guid userId, string brand, string name, int seats)
        {
            var driver = await _driverRepository.GetAsync(userId);
            
            if(driver is null)
                throw new ArgumentException($"Driver with ${userId} not exist");
            
            //check detail from vehickle provider later

            var vehickle = Vehicle.Create(brand, name, seats);
            driver.SetVehickle(vehickle);
            await _driverRepository.UpdateAsync(driver);
        }

        public async Task RemoveAsync(Guid userId)
        {
            var driver = await _driverRepository.GetAsync(userId);
            if (driver is null)
                throw new ArgumentException($"Driver with Id: {userId} not exist");

            await _driverRepository.RemoveAsync(driver);
        }
    }
}