using System;
using System.Threading;
using System.Threading.Tasks;
using EngineeringWork.Core.Domain;
using EngineeringWork.Core.Interface.Repositories;
using EngineeringWork.Core.Interface.Services.NodeService;
using EngineeringWork.Infrastructure.Commands.Drivers;
using EngineeringWork.Infrastructure.Services.NodeService;
using MediatR;

namespace EngineeringWork.Infrastructure.CommandHandlers.DriversHandler
{
    public class DriverHandler : IRequestHandler<CreateDriver>, IRequestHandler<RemoveDriver>, IRequestHandler<SetVehickle>
    {
        private readonly INodeManager _nodeManager;


        private readonly IDriverRepository _driverRepository;
        
        public DriverHandler(INodeManager nodeManager, IDriverRepository driverRepository)
        {
            _nodeManager = nodeManager;
            _driverRepository = driverRepository;
        }

        public async Task<Unit> Handle(CreateDriver request, CancellationToken cancellationToken)
        {
            var driver = await _driverRepository.GetAsync(request.UserId);
            if(driver !=  null)
                throw new ArgumentException($"Driver with Id: {request.UserId} actual exist");

            var _driver = new Driver(request.UserId);
            await _driverRepository.AddAsync(_driver); 
            return Unit.Value;
        }

        public async Task<Unit> Handle(RemoveDriver request, CancellationToken cancellationToken)
        {
            var driver = await _driverRepository.GetAsync(request.UserId);
            if (driver is null)
                throw new ArgumentException($"Driver with Id: {request.UserId} not exist");

            await _driverRepository.RemoveAsync(driver);
            return Unit.Value;
        }

        public async Task<Unit> Handle(SetVehickle request, CancellationToken cancellationToken)
        {
            var driver = await _driverRepository.GetAsync(request.UserId);
            
            if(driver is null)
                throw new ArgumentException($"Driver with ${request.UserId} not exist");
            //check detail from vehickle provider later
            var vehickle = Vehicle.Create(request.brand, request.name, request.seats);
            driver.SetVehickle(vehickle);
            await _driverRepository.UpdateAsync(driver);
            return Unit.Value;
        }
    }
}