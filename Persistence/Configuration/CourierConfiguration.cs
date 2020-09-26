using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration {
    class CourierConfiguration : IEntityTypeConfiguration<Courier> {
        public void Configure (EntityTypeBuilder<Courier> builder) {
            builder.HasKey (e => e.IdCourier);

            builder.Property (e => e.CourierArea)
                .HasColumnType ("Uniqueidentifier")
                .ValueGeneratedOnAdd ();

            builder.Property (e => e.CourierPhoneNumber)
                .HasColumnType ("nvarchar(12)")
                .HasMaxLength (12);

            builder.Property (e => e.CourierStatus)
                .HasColumnType ("SMALLINT")
                .HasMaxLength (2);

            builder.Property (e => e.CourierPlateNumber)
                .HasColumnType ("nvarchar(15)")
                .HasMaxLength (15);

            builder.Property (e => e.CourierArea)
                .HasColumnType ("nvarchar(25)")
                .HasMaxLength (25);

            builder.HasIndex (e => e.IdCourier);
            builder.HasIndex (e => e.CourierName);
            builder.HasIndex (e => e.CourierPhoneNumber);
            builder.HasIndex (e => e.CourierStatus);
            builder.HasIndex (e => e.CourierPlateNumber);
            builder.HasIndex (e => e.CourierArea);
        }
    }
}