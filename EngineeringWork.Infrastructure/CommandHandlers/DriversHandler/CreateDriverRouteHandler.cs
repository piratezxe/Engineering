﻿using EngineeringWork.Core.Domain;
using EngineeringWork.Core.Interface.Repositories;
using EngineeringWork.Core.Interface.Services.NodeService;
using EngineeringWork.Infrastructure.Commands.Drivers;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace EngineeringWork.Infrastructure.CommandHandlers.DriversHandler
{
    public class CreateDriverRouteHandler : IRequestHandler<CreatedDriverRoute>
    {
        private readonly IDriverRepository _driverRepository;

        private readonly INodeManager _nodeManager;
        public CreateDriverRouteHandler(IDriverRepository driverRepository, INodeManager nodeManager)
        {
            _driverRepository = driverRepository;
            _nodeManager = nodeManager;
        }
        public async Task<Unit> Handle(CreatedDriverRoute request, CancellationToken cancellationToken)
        {
            var driver = await _driverRepository.GetAsync(request.UserId);
            if (driver is null)
                throw new ArgumentException($"Driver with {request.UserId} not exist");

            var startNodeAddress = await _nodeManager.GetAdrressAsync(request.StartLatitude, request.StartLongitude);
            var endNodeAdress = await _nodeManager.GetAdrressAsync(request.EndLatitude, request.EndLongitude);

            var startNode = Node.Create(startNodeAddress, request.StartLatitude, request.StartLongitude);
            var endNode = Node.Create(endNodeAdress, request.EndLatitude, request.EndLongitude);
            driver.AddDailyRoute(Guid.NewGuid(), startNode, endNode, request.StartTime, request.FreeSeats);
            await _driverRepository.UpdateAsync(driver);
            return Unit.Value;
        }
    }
}