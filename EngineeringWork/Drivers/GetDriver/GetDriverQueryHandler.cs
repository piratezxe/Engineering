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
    public class GetDriverQueryHandler : IRequestHandler<GetDriverQuery, DriverDto>
    {
        private readonly IDriverRepository _driverRepository;
        private readonly IMapper _mapper;
        public GetDriverQueryHandler(IDriverRepository driverRepository, IMapper mapper)
        {
            _mapper = mapper;
            _driverRepository = driverRepository;
        }
        public async Task<DriverDto> Handle(GetDriverQuery request, CancellationToken cancellationToken)
        {
            var driver = await _driverRepository.GetAsync(request.DriverId);
            return _mapper.Map<Driver, DriverDto>(driver);
        }
    }
}
