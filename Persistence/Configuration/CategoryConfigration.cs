using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration {
    class CategoryConfigration : IEntityTypeConfiguration<Category> {
        public void Configure (EntityTypeBuilder<Category> builder) {
            builder.HasKey (e => e.IdCategory);

            builder.Property (e => e.IdCategory)
                .HasColumnType ("Uniqueidentifier")
                .ValueGeneratedOnAdd ();

            builder.Property (e => e.CategoryName)
                .HasColumnType ("nvarchar(25)")
                .HasMaxLength (25);

            builder.Property (e => e.ImageUrl)
                .HasColumnType ("nvarchar(25)")
                .HasMaxLength (25);

            builder.HasIndex (e => e.IdCategory);
            builder.HasIndex (e => e.CategoryName);
            builder.HasIndex (e => e.ImageUrl);
        }
    }
}