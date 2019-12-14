using System;
using EngineeringWork.Core.DTO;
using MediatR;

namespace EngineeringWork.Web.Application.Drivers.GetDriver
{
    public class GetDriverQuery : IRequest<DriverDto>
    {
        public Guid DriverId { get; set; }
    }
}