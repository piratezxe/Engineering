using EngineeringWork.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EngineeringWork.Core.Configuration
{
    public class PassengerBookingProposalEntityTypeConfiguration : IEntityTypeConfiguration<PassengerBookingProposal>
    {
        public void Configure(EntityTypeBuilder<PassengerBookingProposal> builder)
        {
            builder.OwnsOne(x => x.PassengerBookingProposalDecision);
        }
    }
}