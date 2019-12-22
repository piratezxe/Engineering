using System;
using EngineeringWork.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EngineeringWork.Core.Configuration
{
    public class PassengerBookingProposalDecisionEntityTypeConfiguration : IEntityTypeConfiguration<PassengerBookingProposalDecision>
    {
        public void Configure(EntityTypeBuilder<PassengerBookingProposalDecision> builder)
        {
            builder
                .Property(e => e.ProposalStatus)
                .HasConversion(
                    v => v.ToString(),
                    v => (ProposalStatus)Enum.Parse(typeof(ProposalStatus), v));
        }
    }
}