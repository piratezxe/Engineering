using System.Threading.Tasks;
using Passenger.Infrastructure.Commands;
using Passenger.Infrastructure.Commands.Drivers;
using Passenger.Infrastructure.Services.DriverService;

namespace Passenger.Infrastructure.Handlers.Drivers
{
    public class SetVehickleHandler : ICommandHandler<SetVehickle>
    {
        private readonly IDriverService _driverService;

        public SetVehickleHandler(IDriverService driverService)
        {
            _driverService = driverService;
        }

        public async Task HandleAsync(SetVehickle command)
        {
            await _driverService.SetVehickle(command.UserId, command.brand, command.name, command.seats);
        }
    }
}