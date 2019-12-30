using System.Threading;
using System.Threading.Tasks;
using EngineeringWork.Core.Domain;
using EngineeringWork.Infrastructure.Extensions;
using EngineeringWork.Infrastructure.Services.NodeService;
using EngineeringWork.Repository.Repositories.Interface;
using MediatR;

namespace EngineeringWork.Infrastructure.Application.Drivers.SetDriverVehickle
{
    public class SetDriverVehicleCommandHandler : IRequestHandler<SetVehickleCommand>
    {
        private readonly INodeManager _nodeManager;


        private readonly IDriverRepository _driverRepository;
        
        public SetDriverVehicleCommandHandler(INodeManager nodeManager, IDriverRepository driverRepository)
        {
            _nodeManager = nodeManager;
            _driverRepository = driverRepository;
        }
        public async Task<Unit> Handle(SetVehickleCommand request, CancellationToken cancellationToken)
        {
            var driver = await _driverRepository.GetOrFailAsync(request.UserId);

            var vehicle = Vehicle.Create(request.brand, request.name, request.seats);
            driver.SetVehicle(vehicle);
            await _driverRepository.UpdateAsync(driver);
            return Unit.Value;
        }
    }
}