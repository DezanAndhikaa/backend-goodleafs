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

namespace Application.Product.Queries {
    public class GetAllDealDayProductQueries : IRequest<List<ProductsDto>> { }

    public class GetAllDealDayProductQueriesHandler : BaseCommandHandler<GetAllDealDayProductQueriesHandler>, IRequestHandler<GetAllDealDayProductQueries, List<ProductsDto>> {
        public GetAllDealDayProductQueriesHandler (IAppDbContext context, IMapper mapper, ILogger<GetAllDealDayProductQueriesHandler> logger) : base (context, mapper, logger) { }

        public async Task<List<ProductsDto>> Handle (GetAllDealDayProductQueries request, CancellationToken cancellationToken) {

            var entity = await Context.Products.Where (x => x.IsDealoftheDay == true).ProjectTo<ProductsDto> (Mapper.ConfigurationProvider).ToListAsync (cancellationToken);

            return entity;

        }
    }
}