using System.Threading.Tasks;
using Passenger.Infrastructure.Commands;
using Passenger.Infrastructure.Commands.Passenger;
using Passenger.Infrastructure.Services.PassengerService;

namespace Passenger.Infrastructure.Handlers.Passenger
{
    public class RemovePassengerFromRouteHandler : ICommandHandler<RemovePassengerFromRoute>
    {
        private readonly IPassengerService _passengerService;

        public RemovePassengerFromRouteHandler(IPassengerService passengerService)
        {
            _passengerService = passengerService;
        }

        public async Task HandleAsync(RemovePassengerFromRoute command)
        {
            await _passengerService.RemovePassengerFromRoute(command.UserId, command.RouteId);
        }
    }
}