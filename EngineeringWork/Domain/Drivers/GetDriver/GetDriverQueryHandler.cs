using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using EngineeringWork.Core.Domain;
using EngineeringWork.Core.DTO;
using EngineeringWork.Core.Interface.Repositories;
using MediatR;

namespace EngineeringWork.Web.Domain.Drivers.GetDriver
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
