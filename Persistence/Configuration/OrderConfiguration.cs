using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration {
    class OrderConfiguration : IEntityTypeConfiguration<Order> {
        public void Configure (EntityTypeBuilder<Order> builder) {
            builder.HasKey (e => e.IdOrder);

            builder.Property (e => e.EmailUser)
                .HasColumnType ("nvarchar(50)")
                .HasMaxLength (50);

            builder.Property (e => e.TanggalOrder)
                .HasColumnType ("datetime2");

            builder.Property (e => e.StatusOrder)
                .HasColumnType ("SMALLINT")
                .HasMaxLength (1);

            builder.Property (e => e.IdOrder)
                .HasColumnType ("Uniqueidentifier")
                .ValueGeneratedOnAdd ();

            builder.Property (e => e.IdCourier)
                .HasColumnType ("Uniqueidentifier");

            builder.HasIndex (e => e.EmailUser);
            builder.HasIndex (e => e.IdOrder);
            builder.HasIndex (e => e.StatusOrder);

        }
    }
}