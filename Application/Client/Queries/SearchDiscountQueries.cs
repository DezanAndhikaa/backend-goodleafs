using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Dtos;
using Application.Common.Interface;
using Application.Common.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Application.Client.Queries {
    public class SearchDiscountQueries : IRequest<DiscountDto> {
        public Guid IdDiscount { get; set; }
    }

    public class SearchDiscountQueriesHandler : BaseCommandHandler<SearchDiscountQueriesHandler>, IRequestHandler<SearchDiscountQueries, DiscountDto> {
        public SearchDiscountQueriesHandler (IAppDbContext context, IMapper mapper, ILogger<SearchDiscountQueriesHandler> logger) : base (context, mapper, logger) { }

        public async Task<DiscountDto> Handle (SearchDiscountQueries request, CancellationToken cancellationToken) {
            var entiy = await Context.Discounts.Where (x => x.IdDiscount == request.IdDiscount).ProjectTo<DiscountDto> (Mapper.ConfigurationProvider).FirstOrDefaultAsync (cancellationToken);

            return entiy;
        }
    }
}