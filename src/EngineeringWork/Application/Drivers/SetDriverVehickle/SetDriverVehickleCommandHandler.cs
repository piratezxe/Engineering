using System;
using System.Threading;
using System.Threading.Tasks;
using EngineeringWork.Core.Domain;
using EngineeringWork.Core.Interface.Repositories;
using EngineeringWork.Core.Interface.Services.NodeService;
using MediatR;

namespace EngineeringWork.Web.Domain.Drivers.SetDriverVehickle
{
    public class SetDriverVehickleCommandHandler : IRequestHandler<SetVehickleCommand>
    {
        private readonly INodeManager _nodeManager;


        private readonly IDriverRepository _driverRepository;
        
        public SetDriverVehickleCommandHandler(INodeManager nodeManager, IDriverRepository driverRepository)
        {
            _nodeManager = nodeManager;
            _driverRepository = driverRepository;
        }
        public async Task<Unit> Handle(SetVehickleCommand request, CancellationToken cancellationToken)
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