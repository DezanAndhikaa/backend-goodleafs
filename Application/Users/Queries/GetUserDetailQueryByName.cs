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
    public class GetUserDetailQueryByName : IRequest<List<UserDto>> {
        public string Name { get; set; }
    }

    public class GetUserDetailQueryByNameHandler : BaseCommandHandler<GetUserDetailQueryByNameHandler>, IRequestHandler<GetUserDetailQueryByName, List<UserDto>> {
        public GetUserDetailQueryByNameHandler (IAppDbContext context, IMapper mapper, ILogger<GetUserDetailQueryByNameHandler> logger) : base (context, mapper, logger) { }

        public async Task<List<UserDto>> Handle (GetUserDetailQueryByName request, CancellationToken cancellationToken) {

            var entity = await Context.Users.Where (x => x.Name.Contains (request.Name)).ProjectTo<UserDto> (Mapper.ConfigurationProvider).ToListAsync (cancellationToken);

            if (entity == null) throw new NotFoundException ("Discount", "Discount not found");

            return entity;

        }
    }
}