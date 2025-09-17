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
    public class DonationRequestConfigrations : IEntityTypeConfiguration<DonationRequest>
    {
        public void Configure(EntityTypeBuilder<DonationRequest> builder)
        {
            builder.HasKey(R =>  R.Id);
            builder.Property(R => R.IsUrgent).IsRequired();
            builder.Property(R => R.HospitalLocation).IsRequired();
            builder.Property(R => R.HospitalName).IsRequired();
            builder.Property(R => R.PatientName).IsRequired();
            builder.Property(R => R.RequestDate).IsRequired();
            builder.Property(R => R.Status).HasConversion<string>().IsRequired();
            builder.Property(R => R.NeedBloodType).HasConversion<string>().IsRequired();
        }
    }
}
