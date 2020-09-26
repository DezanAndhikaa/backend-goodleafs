using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Dtos;
using Application.Common.Exceptions;
using Application.Common.Interface;
using Application.Common.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Application.Users.Queries {
    public class GetUserDetailQuery : IRequest<UserDto> {
        public Guid Id { get; set; }
    }

    public class GetUserDetailQueryHandler : BaseCommandHandler<GetUserDetailQueryHandler>, IRequestHandler<GetUserDetailQuery, UserDto> {
        public GetUserDetailQueryHandler (IAppDbContext context, IMapper mapper, ILogger<GetUserDetailQueryHandler> logger) : base (context, mapper, logger) { }

        public async Task<UserDto> Handle (GetUserDetailQuery request, CancellationToken cancellationToken) {
            var entity = await Context.Users.Where (x => x.UserId == request.Id).ProjectTo<UserDto> (Mapper.ConfigurationProvider).FirstOrDefaultAsync (cancellationToken);

            if (entity == null) throw new NotFoundException ("Discount", "Discount not found");

            return entity;

        }
    }
}