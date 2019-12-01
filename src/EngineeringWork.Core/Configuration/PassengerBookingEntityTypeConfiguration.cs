using EngineeringWork.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EngineeringWork.Core.Configuration
{
    public class PassengerBookingEntityTypeConfiguration : IEntityTypeConfiguration<PassengerBooking>
    {
        public void Configure(EntityTypeBuilder<PassengerBooking> builder)
        {
            builder
                .HasOne<DailyRoute>(x => x.DailyRoute)
                .WithMany(d => d.PassengerBookings)
                .HasForeignKey(x => x.DailyRouteId);

        }
    }
}