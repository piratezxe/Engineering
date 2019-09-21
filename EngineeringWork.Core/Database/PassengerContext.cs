using Microsoft.EntityFrameworkCore;
using Passenger.Core.Domain;

namespace Passenger.Core.Database
{
    public class PassengerContext : DbContext
    {
        public PassengerContext(DbContextOptions<PassengerContext> options): base(options)
        {
        }
        
        public DbSet<User> Users { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<DailyRoute> DailyRoutes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
//            modelBuilder.Entity<User>().ToTable("User").HasOne<Driver>();
//            modelBuilder.Entity<RefreshToken>().ToTable("RefreshToken");
//            modelBuilder.Entity<DailyRoute>().ToTable("DailyRoutes").HasMany<PassengerNode>();
//            modelBuilder.Entity<Driver>().ToTable("Driver")
//                .HasMany(b => b.DailyRoutes)
//                .WithOne();
            modelBuilder.Entity<User>().ToTable("User").HasOne<Driver>();
            modelBuilder.Entity<RefreshToken>().ToTable("RefreshToken");
            modelBuilder.Entity<DailyRoute>().ToTable("DailyRoutes");
            modelBuilder.Entity<Driver>().ToTable("Driver");
        }
    }
}