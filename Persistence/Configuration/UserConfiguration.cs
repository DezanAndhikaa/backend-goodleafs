using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration {
    class UserConfiguration : IEntityTypeConfiguration<User> {
        public void Configure (EntityTypeBuilder<User> builder) {
            builder.HasKey (e => e.UserId);

            builder.Property (e => e.UserId)
                .HasColumnType ("Uniqueidentifier")
                .ValueGeneratedOnAdd ();

            builder.Property (e => e.Name)
                .HasColumnType ("nvarchar(50)")
                .HasMaxLength (50);

            builder.Property (e => e.Email)
                .HasColumnType ("nvarchar(50)")
                .HasMaxLength (50);

            builder.Property (e => e.Password)
                .HasColumnType ("nvarchar(25)")
                .HasMaxLength (25);

            builder.Property (e => e.Gender)
                .HasColumnType ("SMALLINT")
                .HasMaxLength (1);

            builder.Property (e => e.Birthday)
                .HasColumnType ("nvarchar(25)")
                .HasMaxLength (25);

            builder.Property (e => e.Address)
                .HasColumnType ("nvarchar(50)")
                .HasMaxLength (50);

            builder.Property (e => e.ZipCode)
                .HasColumnType ("nvarchar(12)")
                .HasMaxLength (12);

            builder.Property (e => e.Hobby)
                .HasColumnType ("nvarchar(12)")
                .HasMaxLength (12);

            builder.Property (e => e.LastOrder)
                .HasColumnType ("datetime2");

            builder.Property (e => e.TotalOrder)
                .HasColumnType ("SMALLINT")
                .HasMaxLength (10);

            builder.Property (e => e.ImageUrl)
                .HasColumnType ("nvarchar(25)")
                .HasMaxLength (25);

            builder.HasIndex (e => e.UserId);
            builder.HasIndex (e => e.Name);
            builder.HasIndex (e => e.Email);
            builder.HasIndex (e => e.Password);
            builder.HasIndex (e => e.Phone);
            builder.HasIndex (e => e.Birthday);
            builder.HasIndex (e => e.Gender);
            builder.HasIndex (e => e.Address);
            builder.HasIndex (e => e.ZipCode);
            builder.HasIndex (e => e.Hobby);
            builder.HasIndex (e => e.LastOrder);
            builder.HasIndex (e => e.TotalOrder);
            builder.HasIndex (e => e.ImageUrl);
        }
    }
}