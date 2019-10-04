using EngineeringWork.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Passenger.Core.Domain;

namespace EngineeringWork.Core.Database
{
    public class PassengerContext : DbContext
    {
        public PassengerContext(DbContextOptions<PassengerContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Domain.Passenger> Passenger { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<DailyRoute> DailyRoutes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}