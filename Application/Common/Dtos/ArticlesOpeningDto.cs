using System;
using Application.Common.Mappings;
using Domain.Entities;

namespace Application.Common.Dtos {
    public class ArticlesOpeningDto : IMapFrom<Article> {
        public string ImageUrl { get; set; }
        public Guid IdArticle { get; set; }
    }
}