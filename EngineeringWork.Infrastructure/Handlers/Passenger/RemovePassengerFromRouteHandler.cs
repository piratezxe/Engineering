using System.Threading.Tasks;
using EngineeringWork.Infrastructure.Commands;
using EngineeringWork.Infrastructure.Commands.PassengerCommands;
using EngineeringWork.Infrastructure.Services.PassengerRouteService;
using EngineeringWork.Infrastructure.Services.PassengerService;

namespace EngineeringWork.Infrastructure.Handlers.Passenger
{
    public class RemovePassengerFromRouteHandler : ICommandHandler<RemovePassengerFromRoute>
    {
        private readonly IPassengerRouteService _passengerRouteService;

        public RemovePassengerFromRouteHandler(IPassengerRouteService passengerRouteService)
        {
            _passengerRouteService = passengerRouteService;
        }

        public async Task HandleAsync(RemovePassengerFromRoute command)
        {
            await _passengerRouteService.RemovePassengerFromRoute(command.UserId, command.RouteId);
        }
    }
}