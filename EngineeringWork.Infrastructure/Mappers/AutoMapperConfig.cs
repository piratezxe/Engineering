using AutoMapper;
using EngineeringWork.Core.Domain;
using EngineeringWork.Infrastructure.DTO;

namespace EngineeringWork.Infrastructure.Mappers
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