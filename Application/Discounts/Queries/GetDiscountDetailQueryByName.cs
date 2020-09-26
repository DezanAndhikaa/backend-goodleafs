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
    public class GetDiscountDetailQueryByName : IRequest<List<DiscountDto>> {
        public string Name { get; set; }
    }

    public class GetDiscountDetailQueryByNameHandler : BaseCommandHandler<GetDiscountDetailQueryByNameHandler>, IRequestHandler<GetDiscountDetailQueryByName, List<DiscountDto>> {
        public GetDiscountDetailQueryByNameHandler (IAppDbContext context, IMapper mapper, ILogger<GetDiscountDetailQueryByNameHandler> logger) : base (context, mapper, logger) { }

        public async Task<List<DiscountDto>> Handle (GetDiscountDetailQueryByName request, CancellationToken cancellationToken) {

            var entity = await Context.Discounts.Where (x => x.DiscountName.Contains (request.Name)).ProjectTo<DiscountDto> (Mapper.ConfigurationProvider).ToListAsync (cancellationToken);

            if (entity == null) throw new NotFoundException ("Discount", "Discount not found");

            return entity;

        }
    }
}