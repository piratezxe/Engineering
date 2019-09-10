using System;
using System.Collections.Generic;

namespace Passenger.Core.Domain
{
    public class Route
    {
        public Guid Id { get; protected set; }

        public String Name { get; private set; }
        
        public Node StartNode { get; protected set; }
        public Node EndNode { get; protected set; }

        protected Route(string name)
        {
            Name = name;
            Id = Guid.NewGuid();
        }

        protected Route(Node startnode, Node endnode, string name)
        {
            StartNode = startnode;
            EndNode = endnode;
            Name = name;
        }

        public static Route Create(Node startnode, Node endnode, string name)
            => new Route(startnode, endnode, name);
    }
}