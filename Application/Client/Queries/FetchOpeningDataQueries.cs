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
    public class FetchOpeningDataQueries : IRequest<OpeningDataDto> {

    }

    public class FetchOpeningDataQueriesHandler : BaseCommandHandler<FetchOpeningDataQueriesHandler>, IRequestHandler<FetchOpeningDataQueries, OpeningDataDto> {
        public FetchOpeningDataQueriesHandler (IAppDbContext context, IMapper mapper, ILogger<FetchOpeningDataQueriesHandler> logger) : base (context, mapper, logger) { }

        public async Task<OpeningDataDto> Handle (FetchOpeningDataQueries request, CancellationToken cancellationToken) {
            var returnResponses = new OpeningDataDto ();
            returnResponses.EtalaseList = new List<CategoryProductDto> ();

            returnResponses.Category = await Context.Categories.ToListAsync (cancellationToken);
            returnResponses.DealoftheDay = await Context.Products.Where (x => x.IsDealoftheDay == true).ProjectTo<ProductsDto> (Mapper.ConfigurationProvider).ToListAsync (cancellationToken);
            returnResponses.Articles = await Context.Articles.Take (5).ProjectTo<ArticlesOpeningDto> (Mapper.ConfigurationProvider).ToListAsync (cancellationToken);

            var listCategories = await Context.Categories.ToListAsync (cancellationToken);

            foreach (var data in listCategories) {
                var newEtalase = new CategoryProductDto {
                    CategoryName = data.CategoryName,

                };

                var product = Context.Products.Where (ab => ab.CategoryName == data.CategoryName).Take (10).ProjectTo<ProductsDto> (Mapper.ConfigurationProvider).ToList ();

                newEtalase.Products = product;

                if (product.Count > 0) {
                    returnResponses.EtalaseList.Add (new CategoryProductDto {
                        CategoryName = data.CategoryName,
                            Products = product,
                    });
                }

            }

            return returnResponses;
        }
    }
}