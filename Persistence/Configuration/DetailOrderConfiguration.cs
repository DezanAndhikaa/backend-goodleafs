using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration {
    class DetailOrderConfiguration : IEntityTypeConfiguration<DetailOrder> {
        public void Configure (EntityTypeBuilder<DetailOrder> builder) {
            builder.HasKey (e => e.IdDetailOrder);

            builder.Property (e => e.IdOrder)
                .HasColumnType ("Uniqueidentifier")
                .ValueGeneratedOnAdd ();

            builder.Property (e => e.IdProducts)
                .HasColumnType ("Uniqueidentifier")
                .ValueGeneratedOnAdd ();

            builder.Property (e => e.TotalProducts)
                .HasColumnType ("int")
                .HasMaxLength (3);

            builder.HasIndex (e => e.IdDetailOrder);
            builder.HasIndex (e => e.IdOrder);
            builder.HasIndex (e => e.IdProducts);

        }
    }
}