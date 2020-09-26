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
    public class GetCourierDetailQueryByName : IRequest<List<CourierDto>> {
        public string Name { get; set; }
    }

    public class GetCourierDetailQueryByNameHandler : BaseCommandHandler<GetCourierDetailQueryByNameHandler>, IRequestHandler<GetCourierDetailQueryByName, List<CourierDto>> {
        public GetCourierDetailQueryByNameHandler (IAppDbContext context, IMapper mapper, ILogger<GetCourierDetailQueryByNameHandler> logger) : base (context, mapper, logger) { }

        public async Task<List<CourierDto>> Handle (GetCourierDetailQueryByName request, CancellationToken cancellationToken) {

            var entity = await Context.Couriers.Where (x => x.CourierName.Contains (request.Name)).ProjectTo<CourierDto> (Mapper.ConfigurationProvider).ToListAsync (cancellationToken);

            if (entity == null) throw new NotFoundException ("Courier", "Courier not found");

            return entity;

        }
    }
}