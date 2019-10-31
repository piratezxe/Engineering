using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EngineeringWork.Core.Domain;
using EngineeringWork.Infrastructure.DTO;

namespace EngineeringWork.Infrastructure.Services.PassengerService
{
    public interface IPassengerService : IService
    {
        Task<Passenger> GetById(Guid passengerId);
        Task CreatePassenger(Guid userId, Adress adress);
    }
}