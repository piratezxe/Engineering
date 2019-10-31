using System;
using System.ComponentModel.DataAnnotations;

namespace EngineeringWork.Core.Domain
{
    public class Route
    {
        [Key]
        public Guid RouteId { get; set; }
        public Guid DailyRouteId { get; set; }
        public DailyRoute DailyRoute { get; set; }
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