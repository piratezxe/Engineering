using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EngineeringWork.Core.Domain;
using EngineeringWork.Core.Interface.Repositories;
using EngineeringWork.Core.Interface.Services.NodeService;
using EngineeringWork.Infrastructure.Commands.Passenger;
using MediatR;

namespace EngineeringWork.Infrastructure.CommandHandlers.PassengerHandler
{
    public class RemovePassengerHandler
    {
        private readonly IPassengerRepository _passengerRepository;

        private readonly IDailyRouteRepository _dailyRouteRepository;

        private readonly INodeManager _nodeManager;

        public RemovePassengerHandler(IPassengerRepository passengerRepository, IDailyRouteRepository dailyRouteRepository, INodeManager nodeManager)
        {
            _passengerRepository = passengerRepository;
            _nodeManager = nodeManager;
            _dailyRouteRepository = dailyRouteRepository;
        }

         public async Task<Unit> Handle(RemovePassengerFromRouteCommand request, CancellationToken cancellationToken)
        {
            var passenger = await _passengerRepository.GetAsync(request.UserId);

            var route = await _dailyRouteRepository.GetAsync(request.RouteId);
            if(route is null)
                throw new ArgumentException($"Route not exist");

            var result = await isPassengerExistInRoute(route.Id, passenger.Id);
            if(result)
                throw new ArgumentException($"Passenger with {passenger.Id} not exist in route {request.RouteId}");
            
            route.RemovePassengerBooking(passenger);
            await _dailyRouteRepository.UpdateAsync(route);
            return Unit.Value;        
        }
        private async Task<bool> isPassengerExistInRoute(Guid routeId, Guid passengerId)
        {
            var dailyRoute = await _dailyRouteRepository.GetAsync(routeId);
            return dailyRoute.passengerBooking.Any(x => x.Passenger.Id == passengerId);
        }
        
      
    }
}