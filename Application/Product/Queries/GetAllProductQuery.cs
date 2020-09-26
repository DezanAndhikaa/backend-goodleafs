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
    public class GetAllProductQuery : IRequest<ResponsesGetDto<ProductsDto>> {
        public int Pagination { get; set; }

        public string Search { get; set; }
    }

    public class GetAllProductQueryHandler : BaseCommandHandler<GetAllProductQueryHandler>, IRequestHandler<GetAllProductQuery, ResponsesGetDto<ProductsDto>> {
        public GetAllProductQueryHandler (IAppDbContext context, IMapper mapper, ILogger<GetAllProductQueryHandler> logger) : base (context, mapper, logger) { }

        public async Task<ResponsesGetDto<ProductsDto>> Handle (GetAllProductQuery request, CancellationToken cancellationToken) {

            request.Pagination = request.Pagination == 0 ? 0 : request.Pagination;
            int skip = request.Pagination * Constant.DefaultPageSize;

            if (request.Search == null) request.Search = "";

            var totalData = Context.Products.ToList ().Count;

            Logger.LogInformation ($"Data search : {request.Search}");

            var entity = await Context.Products.Where (x => x.ProductName.Contains (request.Search)).ProjectTo<ProductsDto> (Mapper.ConfigurationProvider).ToListAsync (cancellationToken);

            entity = entity.Skip (skip).Take (Constant.DefaultPageSize).ToList ();
            var Responses = new ResponsesGetDto<ProductsDto> (totalData, request.Pagination, entity);

            return Responses;

        }
    }
}