using System.Collections.Generic;
using EngineeringWork.Core.DTO;
using MediatR;

namespace EngineeringWork.Infrastructure.Query.Driver
{
    public class BrowseDriverQuery : IRequest<IEnumerable<DriverDto>>
    {
    }
}