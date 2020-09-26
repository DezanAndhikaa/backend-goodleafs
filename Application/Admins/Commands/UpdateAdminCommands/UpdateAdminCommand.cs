using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Interface;
using Application.Common.Models;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Admins.Commands.UpdateAdminCommands {
    public class UpdateAdminCommand : IRequest<string> {
        public Admin Admin { get; set; }
    }

    public class UpdateAdminCommandHandler : BaseCommandHandler<UpdateAdminCommandHandler>, IRequestHandler<UpdateAdminCommand, string> {
        public UpdateAdminCommandHandler (IAppDbContext context, IMapper mapper, ILogger<UpdateAdminCommandHandler> logger) : base (context, mapper, logger) { }

        public async Task<string> Handle (UpdateAdminCommand request, CancellationToken cancellationToken) {
            var entity = Context.Admins.Where (x => x.Username == request.Admin.Username).FirstOrDefault ();

            if (entity == null) throw new NotFoundException ("Article", "Article Not Found!");

            entity.Password = request.Admin.Password;

            await Context.SaveChangesAsync (true, cancellationToken);
            return "Sukses";
        }
    }
}