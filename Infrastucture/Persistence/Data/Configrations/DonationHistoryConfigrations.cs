using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Meduls;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configrations
{
    public class DonationHistoryConfigrations : IEntityTypeConfiguration<DonationHistory>
    {
        public void Configure(EntityTypeBuilder<DonationHistory> builder)
        {
            builder.HasKey(DH => DH.Id);
            builder.HasOne(D => D.Donor)
                   .WithMany(DH=>DH.DonationHistories)
                   .HasForeignKey(D => D.DonerId)
                   .IsRequired();
            builder.HasOne(DR => DR.DonationRequest)
                   .WithMany(DH => DH.DonationHistories)
                   .HasForeignKey(DR => DR.PatieentId)
                   .IsRequired();
            builder.Property(D =>D.DonationDate).IsRequired();
        }
    }
}
