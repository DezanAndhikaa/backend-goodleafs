using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration {
    class ReviewConfiguration : IEntityTypeConfiguration<ReviewsProduct> {
        public void Configure (EntityTypeBuilder<ReviewsProduct> builder) {
            builder.HasKey (e => e.IdReviews);

            builder.Property (e => e.IdProducts)
                .HasColumnType ("Uniqueidentifier")
                .ValueGeneratedOnAdd ();

            builder.Property (e => e.IdReviews)
                .HasColumnType ("Uniqueidentifier")
                .ValueGeneratedOnAdd ();

            builder.Property (e => e.EmailUser)
                .HasColumnType ("nvarchar(50)")
                .HasMaxLength (50);

            builder.Property (e => e.Comment)
                .HasColumnType ("nvarchar(50)")
                .HasMaxLength (50);

            builder.Property (e => e.Rating)
                .HasColumnType ("SMALLINT")
                .HasMaxLength (1);

            builder.HasIndex (e => e.IdReviews);
            builder.HasIndex (e => e.IdProducts);

        }
    }
}