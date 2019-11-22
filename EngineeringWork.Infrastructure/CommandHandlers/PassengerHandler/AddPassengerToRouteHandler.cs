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
    public class AddPassengerToRouteHandler : IRequestHandler<AddPassengerToRouteCommand>
    {
        private readonly IPassengerRepository _passengerRepository;

        private readonly IDailyRouteRepository _dailyRouteRepository;

        private readonly INodeManager _nodeManager;

        public AddPassengerToRouteHandler(IPassengerRepository passengerRepository, IDailyRouteRepository dailyRouteRepository, INodeManager nodeManager)
        {
            _passengerRepository = passengerRepository;
            _nodeManager = nodeManager;
            _dailyRouteRepository = dailyRouteRepository;
        }

        public async Task<Unit> Handle(AddPassengerToRouteCommand notification, CancellationToken cancellationToken)
        {
            var passenger = await _passengerRepository.GetAsync(notification.UserId);
            var route = await _dailyRouteRepository.GetAsync(notification.RouteId);
            if(route is null)
                throw new ArgumentNullException($"Route with id: {notification.RouteId} not exist");

            var booking = Booking.Create(Guid.NewGuid());

            route.AddPassengerBooking(passenger, booking);
            await _dailyRouteRepository.UpdateAsync(route);      
            return Unit.Value;
        }
    } 
}