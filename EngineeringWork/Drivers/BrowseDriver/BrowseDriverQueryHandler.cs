using AutoMapper;
using EngineeringWork.Core.Domain;
using EngineeringWork.Core.DTO;
using EngineeringWork.Core.Interface.Repositories;
using EngineeringWork.Infrastructure.Query.Driver;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EngineeringWork.Infrastructure.QueryHandlers.DriverHandler
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
