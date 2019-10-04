using System;
using System.ComponentModel.DataAnnotations;
using EngineeringWork.Core.Domain;

namespace Passenger.Core.Domain
{
    public class PassengerNode
    {
        [Key]
        public Guid Id { get; set; }
        public Node Node { get; protected set; }
        public EngineeringWork.Core.Domain.Passenger Passenger { get; protected set; }

        protected PassengerNode()
        {
        }

        protected PassengerNode(EngineeringWork.Core.Domain.Passenger passenger, Node node)
        {
            Passenger = passenger;
            Node = node;
        }

        public static PassengerNode Create(EngineeringWork.Core.Domain.Passenger passenger, Node node)
            => new PassengerNode(passenger, node);
    }
}