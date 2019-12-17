using EngineeringWork.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EngineeringWork.Core.Configuration
{
    public class DailyRouteEntityTypeConfiguration : IEntityTypeConfiguration<DailyRoute>
    {
        public void Configure(EntityTypeBuilder<DailyRoute> builder)
        {
            builder.OwnsOne(x => x.MoneyValue);
        }
    }
}