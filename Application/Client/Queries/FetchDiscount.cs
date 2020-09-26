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
    public class FetchDiscount : IRequest<List<DiscountDto>> {

    }

    public class FetchDiscountHandler : BaseCommandHandler<FetchDiscount>, IRequestHandler<FetchDiscount, List<DiscountDto>> {
        public FetchDiscountHandler (IAppDbContext context, IMapper mapper, ILogger<FetchDiscount> logger) : base (context, mapper, logger) { }

        public async Task<List<DiscountDto>> Handle (FetchDiscount request, CancellationToken cancellationToken) {
            var dateTimeNow = DateTime.Now;
            var entity = await Context.Discounts.Where (x => x.DiscountEnd < dateTimeNow).ProjectTo<DiscountDto> (Mapper.ConfigurationProvider).ToListAsync (cancellationToken);

            return entity;
        }
    }
}