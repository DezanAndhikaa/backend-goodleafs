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

namespace Application.Users.Commands.DeleteUserCommands {
    public class DeleteUserCommand : IRequest<string> {
        public Guid Id { get; set; }
    }

    public class DeleteUserCommandHandler : BaseCommandHandler<DeleteUserCommandHandler>, IRequestHandler<DeleteUserCommand, string> {
        public DeleteUserCommandHandler (IAppDbContext context, IMapper mapper, ILogger<DeleteUserCommandHandler> logger) : base (context, mapper, logger) { }

        public async Task<string> Handle (DeleteUserCommand request, CancellationToken cancellationToken) {
            var entity = Context.Users.Where (x => x.UserId == request.Id).FirstOrDefault ();

            if (entity == null) throw new NotFoundException ("Users", "Users not found!");

            Context.Users.Remove (entity);
            await Context.SaveChangesAsync (true, cancellationToken);

            return "Sukses";
        }
    }
}