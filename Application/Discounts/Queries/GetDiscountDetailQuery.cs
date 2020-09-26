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

namespace Application.Discounts.Queries {
    public class GetDiscountDetailQuery : IRequest<DiscountDto> {
        public Guid Id { get; set; }
    }

    public class GetDiscountDetailQueryHandler : BaseCommandHandler<GetDiscountDetailQueryHandler>, IRequestHandler<GetDiscountDetailQuery, DiscountDto> {
        public GetDiscountDetailQueryHandler (IAppDbContext context, IMapper mapper, ILogger<GetDiscountDetailQueryHandler> logger) : base (context, mapper, logger) { }

        public async Task<DiscountDto> Handle (GetDiscountDetailQuery request, CancellationToken cancellationToken) {
            var entity = await Context.Discounts.Where (x => x.IdDiscount == request.Id).ProjectTo<DiscountDto> (Mapper.ConfigurationProvider).FirstOrDefaultAsync (cancellationToken);

            if (entity == null) throw new NotFoundException ("Discount", "Discount not found");

            return entity;

        }
    }
}