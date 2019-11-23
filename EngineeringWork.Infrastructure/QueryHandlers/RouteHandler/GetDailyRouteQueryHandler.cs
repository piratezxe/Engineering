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
    public class GetDailyRouteQueryHandler : 
        IRequestHandler<GetDailyRouteQuery, DailyRouteDto>
        
    {
        private readonly IDailyRouteRepository _routeRepository;
        private readonly IMapper _mapper;   

        public GetDailyRouteQueryHandler(IDailyRouteRepository routeRepository, IMapper mapper)
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
    }
}