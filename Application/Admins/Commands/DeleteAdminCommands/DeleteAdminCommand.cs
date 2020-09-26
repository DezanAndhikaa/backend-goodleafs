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

namespace Application.Admins.Commands.DeleteAdminCommands {
    public class DeleteAdminCommand : IRequest<string> {
        public string Username { get; set; }
    }

    public class DeleteAdminCommandHandler : BaseCommandHandler<DeleteAdminCommandHandler>, IRequestHandler<DeleteAdminCommand, string> {
        public DeleteAdminCommandHandler (IAppDbContext context, IMapper mapper, ILogger<DeleteAdminCommandHandler> logger) : base (context, mapper, logger) { }

        public async Task<string> Handle (DeleteAdminCommand request, CancellationToken cancellationToken) {
            var entity = Context.Admins.Where (x => x.Username == request.Username).FirstOrDefault ();

            if (entity == null) throw new NotFoundException ("Article", "Article not found!");

            Context.Admins.Remove (entity);
            await Context.SaveChangesAsync (true, cancellationToken);

            return "Sukses";
        }
    }
}