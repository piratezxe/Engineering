using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using EngineeringWork.Core.Domain;
using EngineeringWork.Core.DTO;
using EngineeringWork.Core.Interface.Repositories;
using EngineeringWork.Infrastructure.Query.DailyRoute;
using MediatR;

namespace EngineeringWork.Infrastructure.QueryHandlers.RouteHandler
{ 
    public class GetDailyRotueByIdQueryHandler : 
        IRequestHandler<GetDailyRouteQuery, DailyRouteDto>, 
        IRequestHandler<GetDailyRouteByLocationQuery, IEnumerable<DailyRouteDto>>,
        IRequestHandler<BrowseDailyRouteQuery, IEnumerable<DailyRouteDto>>
    {
        private readonly IRouteRepository _routeRepository;
        private readonly IMapper _mapper;   

        public GetDailyRotueByIdQueryHandler(IRouteRepository routeRepository, IMapper mapper)
        {
            _routeRepository = routeRepository;
            _mapper = mapper;
        }

        public async Task<DailyRouteDto> Handle(GetDailyRouteQuery request, CancellationToken cancellationToken)
        {
            var dailyRoute = await _routeRepository.GetAsync(request.Id);
            if(dailyRoute is null)
                throw new ArgumentNullException($"Route with {request.Id} not exist");
            return _mapper.Map<DailyRoute, DailyRouteDto>(dailyRoute);
        }

        public async Task<IEnumerable<DailyRouteDto>> Handle(GetDailyRouteByLocationQuery request, CancellationToken cancellationToken)
        {
            var route = await _routeRepository.GetAsyncByPlace(request.StartPlace, request.EndPlace);
            var routeByLocation = route.ToList();
            if (!routeByLocation.Any())
                throw new ArgumentException($"Route start at {request.StartPlace} and end at {request.EndPlace} not exist");
            return _mapper.Map<IEnumerable<DailyRoute>, IEnumerable<DailyRouteDto>>(routeByLocation);        
        }

        public async Task<IEnumerable<DailyRouteDto>> Handle(BrowseDailyRouteQuery request, CancellationToken cancellationToken)
        {
            var rotues = await _routeRepository.BrowseAsync(null);
            return _mapper.Map<IEnumerable<DailyRoute>, IEnumerable<DailyRouteDto>>(rotues);        
        }
    }
}