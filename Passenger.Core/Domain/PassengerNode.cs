using System;
using System.ComponentModel.DataAnnotations;

namespace Passenger.Core.Domain
{
    public class PassengerNode
    {
        [Key]
        public Guid Id { get; set; }
        public Node Node { get; protected set; }
        public Passenger Passenger { get; protected set; }

        protected PassengerNode()
        {
        }

        protected PassengerNode(Passenger passenger, Node node)
        {
            Passenger = passenger;
            Node = node;
        }

        public static PassengerNode Create(Passenger passenger, Node node)
            => new PassengerNode(passenger, node);
    }
}