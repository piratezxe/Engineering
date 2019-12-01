using System;
using System.Threading;
using System.Threading.Tasks;
using EngineeringWork.Core.Interface.Repositories;
using EngineeringWork.Core.Interface.Services.NodeService;
using MediatR;

namespace EngineeringWork.Web.Domain.Drivers.RemoveDriver
{
    public class RemoveDriverCommandHandler : IRequestHandler<RemoveDriverCommand>
    {
        private readonly INodeManager _nodeManager;

        private readonly IDriverRepository _driverRepository;

        public RemoveDriverCommandHandler(INodeManager nodeManager, IDriverRepository driverRepository)
        {
            _nodeManager = nodeManager;
            _driverRepository = driverRepository;
        }

        public async Task<Unit> Handle(RemoveDriverCommand request, CancellationToken cancellationToken)
        {
            var driver = await _driverRepository.GetAsync(request.UserId);
            if (driver is null)
                throw new ArgumentException($"Driver with Id: {request.UserId} not exist");

            await _driverRepository.RemoveAsync(driver);
            return Unit.Value;
        }
    }
}
