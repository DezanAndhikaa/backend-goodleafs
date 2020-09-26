using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Interface;
using Application.Common.Models;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Articles.Commands.DeleteArticleCommands {
    public class DeleteArticleCommand : IRequest<string> {
        public Guid Id { get; set; }
    }

    public class DeleteArticleCommandHandler : BaseCommandHandler<DeleteArticleCommandHandler>, IRequestHandler<DeleteArticleCommand, string> {
        public DeleteArticleCommandHandler (IAppDbContext context, IMapper mapper, ILogger<DeleteArticleCommandHandler> logger) : base (context, mapper, logger) { }

        public async Task<string> Handle (DeleteArticleCommand request, CancellationToken cancellationToken) {
            var entity = Context.Articles.Where (x => x.IdArticle == request.Id).FirstOrDefault ();

            if (entity == null) throw new NotFoundException ("Article", "Article not found!");

            Context.Articles.Remove (entity);
            await Context.SaveChangesAsync (true, cancellationToken);

            return "Sukses";
        }
    }
}