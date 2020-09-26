using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Interface;
using Application.Common.Models;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Application.Users.Queries {
    public class UserLoginQuery : IRequest<string> {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class UserLoginQueryHandler : BaseCommandHandler<UserLoginQueryHandler>, IRequestHandler<UserLoginQuery, string> {
        public UserLoginQueryHandler (IAppDbContext context, IMapper mapper, ILogger<UserLoginQueryHandler> logger) : base (context, mapper, logger) { }

        public async Task<string> Handle (UserLoginQuery request, CancellationToken cancellationToken) {
            var entity = await Context.Users.Where (x => x.Email == request.Email && x.Password == request.Password).FirstOrDefaultAsync (cancellationToken);

            if (entity == null) throw new NotFoundException ("User", "Not found");

            return entity.Name;
        }
    }
}