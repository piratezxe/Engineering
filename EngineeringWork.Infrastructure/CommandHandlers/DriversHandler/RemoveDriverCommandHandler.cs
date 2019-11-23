using EngineeringWork.Core.Interface.Repositories;
using EngineeringWork.Core.Interface.Services.NodeService;
using EngineeringWork.Infrastructure.Commands.Drivers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EngineeringWork.Infrastructure.CommandHandlers.DriversHandler
{
    public class RemoveDriverCommandHandler : IRequestHandler<RemoveDriver>
    {
        private readonly INodeManager _nodeManager;

        private readonly IDriverRepository _driverRepository;

        public RemoveDriverCommandHandler(INodeManager nodeManager, IDriverRepository driverRepository)
        {
            _nodeManager = nodeManager;
            _driverRepository = driverRepository;
        }

        public async Task<Unit> Handle(RemoveDriver request, CancellationToken cancellationToken)
        {
            var driver = await _driverRepository.GetAsync(request.UserId);
            if (driver is null)
                throw new ArgumentException($"Driver with Id: {request.UserId} not exist");

            await _driverRepository.RemoveAsync(driver);
            return Unit.Value;
        }
    }
}
