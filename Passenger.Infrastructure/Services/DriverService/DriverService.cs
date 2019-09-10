using System;
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
        private readonly IUserRepository _userRepository;

        public DriverService(IDriverRepository driverRepository, IMapper mapper, IUserRepository userRepository)
        {
            _driverRepository = driverRepository;
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<DriverDto> GetAsync(Guid userId)
        {
            var driver = await _driverRepository.GetAsync(userId);
            
            return _mapper.Map<Driver,DriverDto>(driver);
        }

        public async Task CreateAsync(Guid userId)
        {
            var user = _userRepository.GetAsync(userId);

            if (user is null)
                throw new ArgumentException($"User with userId {userId} not exist");

            var driver = _driverRepository.GetAsync(userId);
            if(driver !=  null)
                throw new ArgumentException($"Driver with Id: {userId} not exist");

            var _driver = new Driver(userId);
            await _driverRepository.AddAsync(_driver);
        }

        public async Task<IEnumerable<Driver>> BrowseAsync()
            => await _driverRepository.GetAllAsync();

        public async Task RemoveAsync(Guid userId)
        {
            var user = _userRepository.GetAsync(userId);
            if (user is null)
                throw new ArgumentException($"User with userId {userId} not exist");

            var driver = await _driverRepository.GetAsync(userId);
            if (driver == null)
                throw new ArgumentException($"Driver with Id: {userId} not exist");

            await _driverRepository.RemoveAsync(driver);
        }
    }
}