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
    public class FetchProduct : IRequest<ResponsesGetDto<ProductsDto>> {
        public int Pagination { get; set; }
    }

    public class FetchProductHandler : BaseCommandHandler<FetchProductHandler>, IRequestHandler<FetchProduct, ResponsesGetDto<ProductsDto>> {
        public FetchProductHandler (IAppDbContext context, IMapper mapper, ILogger<FetchProductHandler> logger) : base (context, mapper, logger) { }

        public async Task<ResponsesGetDto<ProductsDto>> Handle (FetchProduct request, CancellationToken cancellationToken) {
            request.Pagination = request.Pagination == 0 ? 0 : request.Pagination;
            int skip = request.Pagination * Constant.DefaultPageSize;

            var totalData = Context.Products.ToList ().Count;

            var entity = await Context.Products.Where (x => x.Stock > 0).Skip (skip).Take (Constant.DefaultPageSize).
            ProjectTo<ProductsDto> (Mapper.ConfigurationProvider).ToListAsync (cancellationToken);

            var Responses = new ResponsesGetDto<ProductsDto> (totalData, request.Pagination, entity);

            return Responses;
        }
    }
}