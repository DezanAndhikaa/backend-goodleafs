using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interface;
using Application.Common.Models;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Application.Articles.Commands.CreateArticleCommands {
    public class CreateArticleCommand : IRequest<string> {
        public Article Article { get; set; }
        public IFormFile ArticleBanner { get; set; }
    }

    public class CreateArticleCommandHandler : BaseCommandHandler<CreateArticleCommandHandler>,
        IRequestHandler<CreateArticleCommand, string> {
            public CreateArticleCommandHandler (IAppDbContext context, IMapper mapper, ILogger<CreateArticleCommandHandler> logger) : base (context, mapper, logger) { }
            private static Random random = new Random ();

            public async Task<string> Handle (CreateArticleCommand request, CancellationToken cancellationToken) {
                request.Article.IdArticle = Guid.NewGuid ();

                var fileName = $"{RandomString(6)}{random.Next(1,999)}{Path.GetExtension(request.ArticleBanner.FileName)}";

                var path = Path.Combine ("./Resources/Articles", fileName);

                using (var stream = System.IO.File.Create (path)) {
                    await request.ArticleBanner.CopyToAsync (stream);
                }

                request.Article.ArticleBanner = fileName;

                Context.Articles.Add (request.Article);
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