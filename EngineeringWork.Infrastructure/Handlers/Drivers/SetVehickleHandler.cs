using System.Threading.Tasks;
using EngineeringWork.Infrastructure.Commands;
using EngineeringWork.Infrastructure.Commands.Drivers;
using EngineeringWork.Infrastructure.Services.DriverService;

namespace EngineeringWork.Infrastructure.Handlers.Drivers
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