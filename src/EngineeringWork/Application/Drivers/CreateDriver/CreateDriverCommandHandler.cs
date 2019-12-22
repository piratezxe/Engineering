using System;
using System.Threading;
using System.Threading.Tasks;
using EngineeringWork.Core.Domain;
using EngineeringWork.Core.Interface.Repositories;
using EngineeringWork.Core.Interface.Services.NodeService;
using MediatR;

namespace EngineeringWork.Web.Application.Drivers.CreateDriver
{
    public class CreateDriverCommandHandler : IRequestHandler<CreateDriverCommand>
    {
        private readonly INodeManager _nodeManager;

        private readonly IDriverRepository _driverRepository;

        public CreateDriverCommandHandler(INodeManager nodeManager, IDriverRepository driverRepository)
        {
            _nodeManager = nodeManager;
            _driverRepository = driverRepository;
        }

        public async Task<Unit> Handle(CreateDriverCommand request, CancellationToken cancellationToken)
        {
            var driver = await _driverRepository.GetAsync(request.UserId);
            if (driver != null)
                throw new ArgumentException($"Driver with Id: {request.UserId} actual exist");

            var _driver = new Driver(request.UserId, request.PhoneNumber);
            await _driverRepository.AddAsync(_driver);
            return Unit.Value;
        }
    }
}
