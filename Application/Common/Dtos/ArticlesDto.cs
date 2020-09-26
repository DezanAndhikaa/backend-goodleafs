using System;
using Application.Common.Mappings;
using Domain.Entities;

namespace Application.Common.Dtos {
    public class ArticlesDto : IMapFrom<Article> {
        public Guid IdArticle { get; set; }
        public string ArticleTitle { get; set; }
        public string ArticleAuthor { get; set; }
        public string ArticleBody { get; set; }
        public string ArticleDate { get; set; }
    }
}