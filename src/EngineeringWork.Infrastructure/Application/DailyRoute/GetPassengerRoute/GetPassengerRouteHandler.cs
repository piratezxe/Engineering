using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using EngineeringWork.Infrastructure.DTO;
using EngineeringWork.Repository.Repositories.Interface;
using MediatR;

namespace EngineeringWork.Infrastructure.Application.DailyRoute.GetPassengerRoute
{
    public class GetPassengerRouteHandler : IRequestHandler<GetPassengerRouteQuery, IEnumerable<DailyRouteDto>>
    {
        private readonly IDailyRouteRepository _routeRepository;

        private readonly IMapper _mapper;

        public GetPassengerRouteHandler(IDailyRouteRepository routeRepository, IMapper mapper)
        {
            _routeRepository = routeRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DailyRouteDto>> Handle(GetPassengerRouteQuery request, CancellationToken cancellationToken)
        {
            //var dailyRoute =  await _routeRepository.BrowseAsync(x => x.PassengerBookings.All(k => k.Passenger.Id == request.UserId));
            //return _mapper.Map<IEnumerable<Core.Domain.DailyRoute>, IEnumerable<DailyRouteDto>>(dailyRoute);    
            throw new System.Exception();
        }
    }
}