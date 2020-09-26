using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration {
    class ArticleConfiguration : IEntityTypeConfiguration<Article> {
        public void Configure (EntityTypeBuilder<Article> builder) {
            builder.HasKey (e => e.IdArticle);

            builder.Property (e => e.IdArticle)
                .HasColumnType ("Uniqueidentifier")
                .ValueGeneratedOnAdd ();

            builder.Property (e => e.ArticleTitle)
                .HasColumnType ("nvarchar(50)")
                .HasMaxLength (50);

            builder.Property (e => e.ArticleBody)
                .HasColumnType ("nvarchar(200)")
                .HasMaxLength (200);

            builder.Property (e => e.ArticleAuthor)
                .HasColumnType ("nvarchar(25)")
                .HasMaxLength (25);

            builder.Property (e => e.ArticleDate)
                .HasColumnType ("nvarchar(20)")
                .HasMaxLength (20);

            builder.Property (e => e.ArticleBanner)
                .HasColumnType ("nvarchar(20)")
                .HasMaxLength (20);

            builder.HasIndex (e => e.IdArticle);
            builder.HasIndex (e => e.ArticleTitle);
            builder.HasIndex (e => e.ArticleBody);
            builder.HasIndex (e => e.ArticleAuthor);
            builder.HasIndex (e => e.ArticleDate);

        }
    }
}