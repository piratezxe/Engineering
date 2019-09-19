using System;

namespace Passenger.Core.Domain
{
    public class Route
    {
        public Guid Id { get; set; }
        public Node StartNode { get; protected set; }
        public Node EndNode { get; protected set; }
        
        protected Route()
        {
            
        }

        protected Route(Node startnode, Node endnode)
        {
            StartNode = startnode;
            EndNode = endnode;
            
        }

        public static Route Create(Node startnode, Node endnode)
            => new Route(startnode, endnode);

    }
}