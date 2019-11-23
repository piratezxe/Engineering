using EngineeringWork.Core.Domain;
using EngineeringWork.Infrastructure.Commands.Auth;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace EngineeringWork.Infrastructure.Commands.PassengerBooking
{
    public class ChangePassengerBooking : AuthCommandBase, IRequest
    {
        public Guid PassengerBookingId { get; set; }

        public BookingStatus BookingStatus { get; set; }
    }
}
