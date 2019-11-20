using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EngineeringWork.Core.Domain;
using EngineeringWork.Core.Interface.Repositories;
using EngineeringWork.Core.Interface.Services.NodeService;
using EngineeringWork.Infrastructure.Commands.Passenger;
using EngineeringWork.Infrastructure.Services.NodeService;
using MediatR;

namespace EngineeringWork.Infrastructure.CommandHandlers.PassengerHandler
{
    public class PassengerHandler : IRequestHandler<AddPassengerToRouteCommand>, IRequestHandler<CreatePassengerCommand>,  IRequestHandler<RemovePassengerFromRouteCommand>
    {
        private readonly IPassengerRepository _passengerRepository;

        private readonly IRouteRepository _routeRepository;

        private readonly INodeManager _nodeManager;

        public PassengerHandler(IPassengerRepository passengerRepository, IRouteRepository routeRepository, INodeManager nodeManager)
        {
            _passengerRepository = passengerRepository;
            _routeRepository = routeRepository;
            _nodeManager = nodeManager;
        }

        public async Task<Unit> Handle(AddPassengerToRouteCommand notification, CancellationToken cancellationToken)
        {
            var passenger = await _passengerRepository.GetAsync(notification.UserId);
            var route = await _routeRepository.GetAsync(notification.RouteId);
            if(route is null)
                throw new ArgumentNullException($"Route with id: {notification.RouteId} not exist");
            
            var address = await _nodeManager.GetAdrressAsync(notification.Latitude, notification.Longitude);
            var node = Node.Create(address, notification.Latitude, notification.Longitude);
            
            route.AddPassengerNode(passenger, node);
            await _routeRepository.UpdateAsync(route);      
            return Unit.Value;
        }

        public async Task<Unit> Handle(CreatePassengerCommand request, CancellationToken cancellationToken)
        {
            await _passengerRepository.CreatePassenger(new Passenger(request.UserId, new Adress(request.Adress.City, request.Adress.Street, request.Adress.ZipCode)));
            return Unit.Value;
        }

        public async Task<Unit> Handle(RemovePassengerFromRouteCommand request, CancellationToken cancellationToken)
        {
            var passenger = await _passengerRepository.GetAsync(request.UserId);

            var route = await _routeRepository.GetAsync(request.RouteId);
            if(route is null)
                throw new ArgumentException($"Route not exist");

            var result = await isPassengerExistInRoute(route.Id, passenger.Id);
            if(result)
                throw new ArgumentException($"Passenger with {passenger.Id} not exist in route {request.RouteId}");
            
            route.RemovePassengerNode(passenger);
            await _routeRepository.UpdateAsync(route);
            return Unit.Value;        
        }
        private async Task<bool> isPassengerExistInRoute(Guid routeId, Guid passengerId)
        {
            var passengerRoute = await GetPassengerRoute(passengerId);
            return passengerRoute.Any(x => x.Route.RouteId == routeId);
        }
        
        private async Task<IEnumerable<DailyRoute>> GetPassengerRoute(Guid passengerId)
        {
            return await _routeRepository.BrowseAsync(x => x.PassengerNodes.All(k => k.Passenger.Id == passengerId));
        }
    } 
}