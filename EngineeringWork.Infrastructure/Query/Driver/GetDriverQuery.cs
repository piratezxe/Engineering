using System;
using EngineeringWork.Core.DTO;
using MediatR;

namespace EngineeringWork.Infrastructure.Query.Driver
{
    public class GetDriverQuery : IRequest<DriverDto>
    {
        public Guid DriverId { get; set; }
    }
}