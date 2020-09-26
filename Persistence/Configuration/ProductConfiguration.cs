using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration {
    class ProductConfiguration : IEntityTypeConfiguration<ProductGL> {
        public void Configure (EntityTypeBuilder<ProductGL> builder) {
            builder.HasKey (e => e.IdProduct);

            builder.Property (e => e.IdProduct)
                .HasColumnType ("Uniqueidentifier")
                .ValueGeneratedOnAdd ();

            builder.Property (e => e.ProductName)
                .HasColumnType ("nvarchar(50)")
                .HasMaxLength (50);

            builder.Property (e => e.VariantName)
                .HasColumnType ("nvarchar(50)")
                .HasMaxLength (50);

            builder.Property (e => e.CategoryName)
                .HasColumnType ("nvarchar(25)")
                .HasMaxLength (25);

            builder.Property (e => e.Cost)
                .HasColumnType ("BIGINT")
                .HasMaxLength (50);

            builder.Property (e => e.ConstAmount)
                .HasColumnType ("SMALLINT")
                .HasMaxLength (12);

            builder.Property (e => e.ImageUrl)
                .HasColumnType ("nvarchar(50)")
                .HasMaxLength (50);

            builder.Property (e => e.BaseColor)
                .HasColumnType ("nvarchar(10)")
                .HasMaxLength (10);

            builder.Property (e => e.IsAvailable)
                .HasColumnType ("BIT");

            builder.Property (e => e.Stock)
                .HasColumnType ("SMALLINT")
                .HasMaxLength (12);

            builder.Property (e => e.Description)
                .HasColumnType ("nvarchar(500)")
                .HasMaxLength (500);

            builder.Property (e => e.IsDealoftheDay)
                .HasColumnType ("BIT");

            builder.HasIndex (e => e.IdProduct);
            builder.HasIndex (e => e.ProductName);
            builder.HasIndex (e => e.VariantName);
            builder.HasIndex (e => e.CategoryName);
            builder.HasIndex (e => e.Cost);
            builder.HasIndex (e => e.ConstAmount);
            builder.HasIndex (e => e.ImageUrl);
            builder.HasIndex (e => e.BaseColor);
            builder.HasIndex (e => e.IsAvailable);
            builder.HasIndex (e => e.Stock);
            builder.HasIndex (e => e.IsDealoftheDay);

        }
    }
}