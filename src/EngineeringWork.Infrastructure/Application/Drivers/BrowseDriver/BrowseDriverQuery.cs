using System.Collections.Generic;
using EngineeringWork.Infrastructure.DTO;
using MediatR;

namespace EngineeringWork.Infrastructure.Application.Drivers.BrowseDriver
{
    public class BrowseDriverQuery : IRequest<IEnumerable<DriverDto>>
    {
    }
}