using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities {
    public class Article {
        public Guid IdArticle { get; set; }
        public string ArticleTitle { get; set; }
        public string ArticleAuthor { get; set; }
        public string ArticleBody { get; set; }
        public string ArticleDate { get; set; }
        public string ArticleBanner { get; set; }
    }
}