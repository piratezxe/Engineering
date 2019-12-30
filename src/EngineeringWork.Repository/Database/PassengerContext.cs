using EngineeringWork.Core.Domain;
using EngineeringWork.Repository.Configuration;
using Microsoft.EntityFrameworkCore;

namespace EngineeringWork.Repository.Database
{
    public class PassengerContext : DbContext
    {
        public PassengerContext(DbContextOptions<PassengerContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Passenger> Passenger { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<DailyRoute> DailyRoutes { get; set; }
        public DbSet<PassengerBookingProposal> PassengerBookingProposals { get; set; }
        
        public DbSet<PassengerBooking> PassengerBookings { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DailyRouteEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new PassengerBookingProposalEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new PassengerBookingProposalDecisionEntityTypeConfiguration());
        }
    }
}