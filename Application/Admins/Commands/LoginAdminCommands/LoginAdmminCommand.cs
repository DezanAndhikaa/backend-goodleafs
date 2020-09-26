using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Interface;
using Application.Common.Models;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Application.Admins.Commands.LoginAdminCommands {
    public class LoginAdmminCommand : IRequest<string> {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class LoginAdminCommandHandler : BaseCommandHandler<LoginAdminCommandHandler>, IRequestHandler<LoginAdmminCommand, string> {
        public LoginAdminCommandHandler (IAppDbContext context, IMapper mapper, ILogger<LoginAdminCommandHandler> logger) : base (context, mapper, logger) { }

        public async Task<string> Handle (LoginAdmminCommand request, CancellationToken cancellationToken) {
            var entity = await Context.Admins.FirstOrDefaultAsync (x => x.Username == request.Username && x.Password == request.Password);

            if (entity == null) throw new NotFoundException ("Admin", "Username or password wrong");

            return entity.Username;
        }
    }
}