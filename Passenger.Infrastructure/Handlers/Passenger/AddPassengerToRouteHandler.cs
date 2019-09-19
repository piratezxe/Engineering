using System.Threading.Tasks;
using Passenger.Infrastructure.Commands;
using Passenger.Infrastructure.Commands.Passenger;
using Passenger.Infrastructure.Services.PassengerService;

namespace Passenger.Infrastructure.Handlers.Passenger
{
    public class AddPassengerToRouteHandler : ICommandHandler<AddPassengerToRoute>
    {
        private readonly IPassengerService _passengerService;

        public AddPassengerToRouteHandler(IPassengerService passengerService)
        {
            _passengerService = passengerService;
        }

        public async Task HandleAsync(AddPassengerToRoute command)
        {
            await _passengerService.AddPassengerToRoute(command.UserId, command.RouteId, command.Latitude,
                command.Longitude);
        }
    } 
}