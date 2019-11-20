using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using EngineeringWork.Core.Domain;
using EngineeringWork.Core.DTO;
using EngineeringWork.Core.Interface.Repositories;
using EngineeringWork.Infrastructure.Query.PassengerQuery;
using MediatR;

namespace EngineeringWork.Infrastructure.QueryHandlers.PassengerHandler
{
    public class PassengerHandler : IRequestHandler<GetPassengerRouteQuery, IEnumerable<DailyRouteDto>>, IRequestHandler<GetPassengerByIdQuery, Passenger>
    {
        private readonly IRouteRepository _routeRepository;

        private readonly IPassengerRepository _passengerRepository;

        private readonly IMapper _mapper;

        public PassengerHandler(IRouteRepository routeRepository, IMapper mapper, IPassengerRepository passengerRepository)
        {
            _routeRepository = routeRepository;
            _mapper = mapper;
            _passengerRepository = passengerRepository;
        }

        public async Task<IEnumerable<DailyRouteDto>> Handle(GetPassengerRouteQuery request, CancellationToken cancellationToken)
        {
            var dailyRoute = await _routeRepository.BrowseAsync(x => x.PassengerNodes.All(k => k.Passenger.Id == request.UserId));
            return _mapper.Map<IEnumerable<DailyRoute>, IEnumerable<DailyRouteDto>>(dailyRoute);        
        }

        public async Task<Passenger> Handle(GetPassengerByIdQuery request, CancellationToken cancellationToken)
        {
            var passenger = await _passengerRepository.GetAsync(request.PassengerId);
            if(passenger is null)
                throw new ArgumentNullException($"Passenger with {request.PassengerId} not exist");
            return passenger;        
        }
    }
}