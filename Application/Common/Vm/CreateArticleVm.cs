using Application.Common.Dtos;
using Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace Application.Common.Vm {
    public class CreateArticleVm {
        public Article Article { get; set; }
        public IFormFile ArticleBanner { get; set; }
    }
}