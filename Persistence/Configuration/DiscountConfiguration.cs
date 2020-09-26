using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Persistence.Configuration {
    class DiscountConfiguration : IEntityTypeConfiguration<Discount> {
        public void Configure (EntityTypeBuilder<Discount> builder) {
            builder.HasKey (e => e.IdDiscount);

            builder.Property (e => e.IdDiscount)
                .HasColumnType ("Uniqueidentifier")
                .ValueGeneratedOnAdd ();

            builder.Property (e => e.DiscountName)
                .HasColumnType ("nvarchar(50)")
                .HasMaxLength (50);

            builder.Property (e => e.DiscountStart)
                .HasColumnType ("datetime2");

            builder.Property (e => e.DiscountEnd)
                .HasColumnType ("datetime2");

            builder.Property (e => e.DiscountType)
                .HasColumnType ("nvarchar(25)")
                .HasMaxLength (25);

            builder.Property (e => e.Content)
                .HasColumnType ("nvarchar(25)")
                .HasMaxLength (25);

            builder.Property (e => e.DiscountBanner)
                .HasColumnType ("nvarchar(25)")
                .HasMaxLength (25);

            builder.Property (e => e.Voucher)
                .HasColumnType ("nvarchar(25)")
                .HasMaxLength (25);

            var splitStringConverter = new ValueConverter<IEnumerable<string>, string> (v => string.Join (";", v), v => v.Split (new [] { ';' }));
            builder.Property (e => e.Items)
                .HasConversion (splitStringConverter);

            builder.HasIndex (e => e.IdDiscount);
            builder.HasIndex (e => e.DiscountName);
            builder.HasIndex (e => e.DiscountStart);
            builder.HasIndex (e => e.DiscountEnd);
            builder.HasIndex (e => e.DiscountType);
            builder.HasIndex (e => e.Content);

        }
    }

}