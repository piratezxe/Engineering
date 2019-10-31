using System.Threading.Tasks;
using EngineeringWork.Infrastructure.Commands;
using EngineeringWork.Infrastructure.Commands.PassengerCommands;
using EngineeringWork.Infrastructure.Services.PassengerRouteService;
using EngineeringWork.Infrastructure.Services.PassengerService;

namespace EngineeringWork.Infrastructure.Handlers.Passenger
{
    public class AddPassengerToRouteHandler : ICommandHandler<AddPassengerToRoute>
    {
        private readonly IPassengerRouteService _passengerRouteService;

        public AddPassengerToRouteHandler()
        {
            _passengerRouteService = _passengerRouteService;
        }

        public async Task HandleAsync(AddPassengerToRoute command)
        {
            await _passengerRouteService.AddPassengerToRoute(command.UserId, command.RouteId, command.Latitude,
                command.Longitude);
        }
    } 
}