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
    public class GetAllProductQueryWithoutPagination : IRequest<List<AllProductDto>> { }

    public class GetAllProductQueryWithoutPaginationHandler : BaseCommandHandler<GetAllProductQueryWithoutPaginationHandler>, IRequestHandler<GetAllProductQueryWithoutPagination, List<AllProductDto>> {
        public GetAllProductQueryWithoutPaginationHandler (IAppDbContext context, IMapper mapper, ILogger<GetAllProductQueryWithoutPaginationHandler> logger) : base (context, mapper, logger) { }

        public async Task<List<AllProductDto>> Handle (GetAllProductQueryWithoutPagination request, CancellationToken cancellationToken) {

            var entity = await Context.Products.ProjectTo<AllProductDto> (Mapper.ConfigurationProvider).ToListAsync (cancellationToken);

            return entity;

        }
    }
}