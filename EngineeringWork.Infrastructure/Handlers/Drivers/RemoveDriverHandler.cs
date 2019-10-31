using System.Threading.Tasks;
using EngineeringWork.Infrastructure.Commands;
using EngineeringWork.Infrastructure.Commands.Drivers;
using EngineeringWork.Infrastructure.Services.DriverService;

namespace EngineeringWork.Infrastructure.Handlers.Drivers
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