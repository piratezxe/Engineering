using System;
using System.Threading;
using System.Threading.Tasks;
using EngineeringWork.Core.Domain;
using EngineeringWork.Core.Interface.Repositories;
using EngineeringWork.Core.Interface.Services.NodeService;
using EngineeringWork.Infrastructure.Extensions.RepositoryExtensions;
using MediatR;

namespace EngineeringWork.Web.Application.DailyRoute.CreateDailyRoute
{

    public class CreateDailyRouteCommandHandler : IRequestHandler<CreateDailyRouteCommand>
    {
        private readonly IDriverRepository _driverRepository;
        private readonly INodeManager _nodeManager;
        
        public CreateDailyRouteCommandHandler(IDriverRepository driverRepository, INodeManager nodeManager)
        {
            _driverRepository = driverRepository;
            _nodeManager = nodeManager;
        }

        public async Task<Unit> Handle(CreateDailyRouteCommand request, CancellationToken cancellationToken)
        {
            var driver = await _driverRepository.GetOrFailAsync(request.UserId);

            var startNodeAddress = await _nodeManager.GetAdrressAsync(request.StartLatitude, request.StartLongitude);
            var endNodeAddress = await _nodeManager.GetAdrressAsync(request.EndLatitude, request.EndLongitude);
            
            var startNode = Node.Create(startNodeAddress, request.StartLatitude, request.StartLongitude);
            var endNode = Node.Create(endNodeAddress, request.EndLatitude, request.EndLongitude);
            
            driver.AddDailyRoute(request.RouteId, startNode, endNode, request.StartDateTime, request.CreateDateTime ,request.FreeSeats, request.MoneyValue);
            await _driverRepository.UpdateAsync(driver);
            return Unit.Value;
        }
    }
}