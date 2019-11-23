using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EngineeringWork.Web.Controllers
{

    public class PassengerBookingController : ApiControllerBase
    {
        public PassengerBookingController(IMediator mediator) : base(mediator)
        {
        }
    }
}
