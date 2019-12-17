using System.Collections.Generic;
using EngineeringWork.Core.DTO;
using MediatR;

namespace EngineeringWork.Web.Application.Drivers.BrowseDriver
{
    public class BrowseDriverQuery : IRequest<IEnumerable<DriverDto>>
    {
    }
}