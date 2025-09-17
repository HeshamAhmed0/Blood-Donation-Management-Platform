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
    public class DonorConfigrations : IEntityTypeConfiguration<Donor>
    {
        public void Configure(EntityTypeBuilder<Donor> builder)
        {
            builder.HasKey(D => D.Id);
            builder.Property(D => D.Name).IsRequired().HasMaxLength(100);
            builder.Property(D => D.CreateAt).IsRequired();
            builder.Property(D => D.BloodType).IsRequired();
            builder.Property(D=>D.UnAvailableFrom).IsRequired();
            builder.Property(D=>D.UnAvailableTo).IsRequired();
            builder.Property(D=>D.LastDonationDate).IsRequired();
            builder.Property(D=>D.PhoneNumber).IsRequired();
            builder.Property(D=>D.Email).IsRequired();
            builder.Property(D=>D.Location).IsRequired();
            builder.Property( D=> D.BloodType).HasConversion<string>().IsRequired();
        }
    }
}
