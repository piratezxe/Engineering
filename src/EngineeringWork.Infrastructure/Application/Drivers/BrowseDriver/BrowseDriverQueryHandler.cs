using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using EngineeringWork.Core.Domain;
using EngineeringWork.Infrastructure.DTO;
using EngineeringWork.Repository.Repositories.Interface;
using MediatR;

namespace EngineeringWork.Infrastructure.Application.Drivers.BrowseDriver
{
    public class BrowseDriverQueryHandler : IRequestHandler<BrowseDriverQuery, IEnumerable<DriverDto>>
    {
        private readonly IDriverRepository _driverRepository;
        private readonly IMapper _mapper;
        public BrowseDriverQueryHandler(IDriverRepository driverRepository, IMapper mapper)
        {
            _driverRepository = driverRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<DriverDto>> Handle(BrowseDriverQuery request, CancellationToken cancellationToken)
        {
            var drivers = await _driverRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<Driver>, IEnumerable<DriverDto>>(drivers);
        }
    }
}
