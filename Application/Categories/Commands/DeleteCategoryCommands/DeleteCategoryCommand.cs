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

namespace Application.Categories.Commands.DeleteCategoryCommands {
    public class DeleteCategoryCommand : IRequest<string> {
        public Guid Id { get; set; }
    }

    public class DeleteCategoryCommandHandler : BaseCommandHandler<DeleteCategoryCommandHandler>, IRequestHandler<DeleteCategoryCommand, string> {
        public DeleteCategoryCommandHandler (IAppDbContext context, IMapper mapper, ILogger<DeleteCategoryCommandHandler> logger) : base (context, mapper, logger) { }

        public async Task<string> Handle (DeleteCategoryCommand request, CancellationToken cancellationToken) {
            var entity = Context.Categories.Where (x => x.IdCategory == request.Id).FirstOrDefault ();

            if (entity == null) throw new NotFoundException ("Category", "Category not found!");

            Context.Categories.Remove (entity);
            await Context.SaveChangesAsync (true, cancellationToken);

            return "Sukses";
        }
    }
}