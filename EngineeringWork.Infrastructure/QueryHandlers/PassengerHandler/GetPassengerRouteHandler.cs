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
    public class PassengerHandler : IRequestHandler<GetPassengerRouteQuery, IEnumerable<DailyRouteDto>>
    {
        private readonly IDailyRouteRepository _routeRepository;

        private readonly IMapper _mapper;

        public PassengerHandler(IDailyRouteRepository routeRepository, IMapper mapper)
        {
            _routeRepository = routeRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DailyRouteDto>> Handle(GetPassengerRouteQuery request, CancellationToken cancellationToken)
        {
            var dailyRoute =  await _routeRepository.BrowseAsync(x => x.passengerBooking.All(k => k.Passenger.Id == request.UserId));
            return _mapper.Map<IEnumerable<DailyRoute>, IEnumerable<DailyRouteDto>>(dailyRoute);        
        }
    }
}