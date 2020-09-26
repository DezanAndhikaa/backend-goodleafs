using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interface;
using Application.Common.Models;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Admins.Commands.CreateAdminCommands {
    public class CreateAdminCommand : IRequest<string> {
        public Admin Admin { get; set; }
    }

    public class CreateAdminCommandHandler : BaseCommandHandler<CreateAdminCommandHandler>,
        IRequestHandler<CreateAdminCommand, string> {
            public CreateAdminCommandHandler (IAppDbContext context, IMapper mapper, ILogger<CreateAdminCommandHandler> logger) : base (context, mapper, logger) { }

            public async Task<string> Handle (CreateAdminCommand request, CancellationToken cancellationToken) {

                Context.Admins.Add (request.Admin);
                await Context.SaveChangesAsync (true, cancellationToken);

                return "Sukses";
            }
        }

}