﻿using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using EngineeringWork.Infrastructure.DTO;
using EngineeringWork.Repository.Repositories.Interface;
using MediatR;

namespace EngineeringWork.Infrastructure.Application.DailyRoute.BrowseDailyRoute
{
    public class BrowseDailyRouteQueryHandler : IRequestHandler<BrowseDailyRouteQuery, IQueryable<DailyRouteDto>>
    {
        private readonly IDailyRouteRepository _routeRepository;
        private readonly IMapper _mapper;

        public BrowseDailyRouteQueryHandler(IDailyRouteRepository routeRepository, IMapper mapper)
        {
            _routeRepository = routeRepository;
            _mapper = mapper;
        }
        public async Task<IQueryable<DailyRouteDto>> Handle(BrowseDailyRouteQuery request, CancellationToken cancellationToken)
        {
            var routes = await _routeRepository.BrowseAsync();
            var mappRoutes = _mapper.Map<IEnumerable<EngineeringWork.Core.Domain.DailyRoute>, IEnumerable<DailyRouteDto>>(routes);
            return mappRoutes.AsQueryable();
        }
    }
}
