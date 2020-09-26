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

namespace Application.Couriers.Queries {
    public class GetCourierDetailQuery : IRequest<CourierDto> {
        public Guid Id { get; set; }
    }

    public class GetCourierDetailQueryHandler : BaseCommandHandler<GetCourierDetailQueryHandler>, IRequestHandler<GetCourierDetailQuery, CourierDto> {
        public GetCourierDetailQueryHandler (IAppDbContext context, IMapper mapper, ILogger<GetCourierDetailQueryHandler> logger) : base (context, mapper, logger) { }

        public async Task<CourierDto> Handle (GetCourierDetailQuery request, CancellationToken cancellationToken) {
            var entity = await Context.Couriers.Where (x => x.IdCourier == request.Id).ProjectTo<CourierDto> (Mapper.ConfigurationProvider).FirstOrDefaultAsync (cancellationToken);

            if (entity == null) throw new NotFoundException ("Courier", "Courier not found");

            return entity;

        }
    }
}