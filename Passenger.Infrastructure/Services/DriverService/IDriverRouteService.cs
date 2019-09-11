using System;
using System.Threading.Tasks;

namespace Passenger.Infrastructure.Services.DriverService
{
    public interface IDriverRouteService : IService
    {
        Task AddRouteAsync(string userEmail, double startLatitude, double endLatitude, double startLongitude, double endLongitude, string startNodeAdress, string endNodeAdress, string routeAdress);

        Task RemoveAsync(string name, Guid driverId);

    }
}