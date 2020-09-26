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

namespace Application.Admins.Queries {
    public class GetAdminDetailQuery : IRequest<AdminDto> {
        public string Username { get; set; }
    }

    public class GetAdminDetailQueryHandler : BaseCommandHandler<GetAdminDetailQueryHandler>, IRequestHandler<GetAdminDetailQuery, AdminDto> {
        public GetAdminDetailQueryHandler (IAppDbContext context, IMapper mapper, ILogger<GetAdminDetailQueryHandler> logger) : base (context, mapper, logger) { }

        public async Task<AdminDto> Handle (GetAdminDetailQuery request, CancellationToken cancellationToken) {
            var entity = await Context.Admins.Where (x => x.Username == request.Username).ProjectTo<AdminDto> (Mapper.ConfigurationProvider).FirstOrDefaultAsync (cancellationToken);

            if (entity == null) throw new NotFoundException ("Product", "Product not found");

            return entity;

        }
    }
}