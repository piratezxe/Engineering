using System.Threading.Tasks;
using Passenger.Infrastructure.Commands;
using Passenger.Infrastructure.Commands.Drivers;
using Passenger.Infrastructure.Services.DriverService;

namespace Passenger.Infrastructure.Handlers.Drivers
{
    public class RemoveDriverHandler : ICommandHandler<RemoveDriver>
    {
        private readonly IDriverService _driverService;

        public RemoveDriverHandler(IDriverService driverService)
        {
            _driverService = driverService;
        }

        public async Task HandleAsync(RemoveDriver command)
        {
            await _driverService.RemoveAsync(command.UserId);
        }
    }
}