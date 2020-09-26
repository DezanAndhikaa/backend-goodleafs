using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Interface;
using Application.Common.Models;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Application.Articles.Commands.UpdateArticleCommands {
    public class UpdateArticleCommand : IRequest<string> {
        public IFormFile ArticleBanner { get; set; }
        public Article Article { get; set; }
    }

    public class UpdateArticleCommandHandler : BaseCommandHandler<UpdateArticleCommandHandler>, IRequestHandler<UpdateArticleCommand, string> {
        public UpdateArticleCommandHandler (IAppDbContext context, IMapper mapper, ILogger<UpdateArticleCommandHandler> logger) : base (context, mapper, logger) { }
        private static Random random = new Random ();

        public async Task<string> Handle (UpdateArticleCommand request, CancellationToken cancellationToken) {
            var entity = Context.Articles.Where (x => x.IdArticle == request.Article.IdArticle).FirstOrDefault ();

            if (entity == null) throw new NotFoundException ("Article", "Article Not Found!");

            entity.ArticleAuthor = request.Article.ArticleAuthor;
            entity.ArticleBody = request.Article.ArticleBody;
            entity.ArticleTitle = request.Article.ArticleTitle;
            entity.ArticleDate = request.Article.ArticleDate;

            if (request.ArticleBanner != null) {
                try {
                    File.Delete (Path.Combine ("./Resources/Discounts", entity.ArticleBanner));
                } catch (Exception e) {
                    Logger.LogError ($"Error when delete file : {e}");
                }

                try {
                    var fileName = $"{RandomString(6)}{random.Next(1,999)}{Path.GetExtension(request.ArticleBanner.FileName)}";
                    var path = Path.Combine ("./Resources/Products", fileName);

                    using (var stream = System.IO.File.Create (path)) {
                        await request.ArticleBanner.CopyToAsync (stream);
                    }
                    entity.ArticleBanner = fileName;
                } catch (Exception e) {
                    Logger.LogError ($"Error when moving file : {e}");

                }
            }
            await Context.SaveChangesAsync (true, cancellationToken);
            return "Sukses";
        }

        public static string RandomString (int length) {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string (Enumerable.Repeat (chars, length)
                .Select (s => s[random.Next (s.Length)]).ToArray ());
        }
    }
}