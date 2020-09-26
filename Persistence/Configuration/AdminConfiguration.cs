using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration {
    class AdminConfiguration : IEntityTypeConfiguration<Admin> {
        public void Configure (EntityTypeBuilder<Admin> builder) {
            builder.HasKey (e => e.Username);

            builder.Property (e => e.Username)
                .HasColumnType ("nvarchar(25)")
                .HasMaxLength (25);

            builder.Property (e => e.Password)
                .HasColumnType ("nvarchar(25)")
                .HasMaxLength (25);

            builder.Property (e => e.Role)
                .HasColumnType ("SMALLINT")
                .HasMaxLength (2);

            builder.HasIndex (e => e.Username);
            builder.HasIndex (e => e.Password);
            builder.HasIndex (e => e.Role);

        }
    }
}