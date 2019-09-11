using System;

namespace Passenger.Infrastructure.Commands.Drivers
{
    public class RemoveDriver : ICommand
    {
        public Guid UserId { get; set; }

    }
}