using System.Security.Policy;
using AutoMapper;
using EngineeringWork.Core.Domain;
using Passenger.Core.Domain;
using Passenger.Infrastructure.DTO;

namespace Passenger.Infrastructure.Mappers
{
    public static class AutoMapperConfig
    {
        public static IMapper Initialize()
            => new MapperConfiguration(cfg => 
            {
                cfg.CreateMap<User, UserDto>();
                cfg.CreateMap<Driver, DriverDto>();
                cfg.CreateMap<DailyRoute, DailyRouteDto>();
                cfg.CreateMap<Route, RouteDto>();
            })
            .CreateMapper();
    }
}