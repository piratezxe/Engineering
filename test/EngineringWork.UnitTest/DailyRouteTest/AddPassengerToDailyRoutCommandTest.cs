using System;
using System.Threading;
using System.Threading.Tasks;
using EngineeringWork.Core.Domain;
using EngineeringWork.Core.Interface.Repositories;
using EngineeringWork.Core.Interface.Services.NodeService;
using EngineeringWork.Web.Domain.DailyRoute;
using EngineeringWork.Web.Domain.DailyRoute.AddPassengerToRoute;
using FluentAssertions;
using MediatR;
using Moq;
using Xunit;

namespace EngineringWork.UnitTest.DailyRouteTest
{
    public class AddPassengerToDailyRoutCommandTest
    {
        [Fact]
        public async Task when_invoke_add_passenger_to_route_command_handler_should_not_be_null()
        {
        }
    }
}