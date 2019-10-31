using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EngineeringWork.Infrastructure.DTO;

namespace EngineeringWork.Infrastructure.Services.DriverService
{
    public interface IDriverRouteService : IService
    {
        Task<IEnumerable<DailyRouteDto>> GetMyDailyRoutes(Guid UserId);
    }
}