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

namespace Application.Client.Queries {
    public class SearchByCategoryQueries : IRequest<List<ProductsDto>> {
        public string CategoryName { get; set; }
    }

    public class SearchByCategoryQueriesHandler : BaseCommandHandler<SearchByCategoryQueriesHandler>, IRequestHandler<SearchByCategoryQueries, List<ProductsDto>> {
        public SearchByCategoryQueriesHandler (IAppDbContext context, IMapper mapper, ILogger<SearchByCategoryQueriesHandler> logger) : base (context, mapper, logger) { }

        public async Task<List<ProductsDto>> Handle (SearchByCategoryQueries request, CancellationToken cancellationToken) {
            var entity = await Context.Products.Where (x => x.CategoryName == request.CategoryName).ProjectTo<ProductsDto> (Mapper.ConfigurationProvider).ToListAsync (cancellationToken);
            if (entity == null) throw new NotFoundException ("Product", "Not found!");

            return entity;
        }
    }

}