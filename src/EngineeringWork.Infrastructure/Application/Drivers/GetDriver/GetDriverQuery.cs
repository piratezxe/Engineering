using System;
using EngineeringWork.Infrastructure.DTO;
using MediatR;

namespace EngineeringWork.Infrastructure.Application.Drivers.GetDriver
{
    public class GetDriverQuery : IRequest<DriverDto>
    {
        public Guid DriverId { get; set; }
    }
}