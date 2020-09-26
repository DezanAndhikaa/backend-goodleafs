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
    public class SearchByNameQueries : IRequest<List<ProductsDto>> {
        public string ProductName { get; set; }
        public List<string> CategoryName { get; set; }
    }

    public class SearchByNameQueriesHandler : BaseCommandHandler<SearchByCategoryQueriesHandler>, IRequestHandler<SearchByNameQueries, List<ProductsDto>> {

        public SearchByNameQueriesHandler (IAppDbContext context, IMapper mapper, ILogger<SearchByCategoryQueriesHandler> logger) : base (context, mapper, logger) { }

        public async Task<List<ProductsDto>> Handle (SearchByNameQueries request, CancellationToken cancellationToken) {
            var entiy = await Context.Products.Where (x => x.ProductName.Contains (request.ProductName) || request.CategoryName.Contains (x.CategoryName)).ProjectTo<ProductsDto> (Mapper.ConfigurationProvider).ToListAsync (cancellationToken);

            return entiy;
        }
    }
}