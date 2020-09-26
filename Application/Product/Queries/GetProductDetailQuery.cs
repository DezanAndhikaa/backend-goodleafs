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
    public class GetProductDetailQuery : IRequest<ProductsDto> {
        public Guid IdProduct { get; set; }
    }

    public class GetProductQueryHandler : BaseCommandHandler<GetProductQueryHandler>, IRequestHandler<GetProductDetailQuery, ProductsDto> {
        public GetProductQueryHandler (IAppDbContext context, IMapper mapper, ILogger<GetProductQueryHandler> logger) : base (context, mapper, logger) { }

        public async Task<ProductsDto> Handle (GetProductDetailQuery request, CancellationToken cancellationToken) {
            var entity = await Context.Products.Where (x => x.IdProduct == request.IdProduct).ProjectTo<ProductsDto> (Mapper.ConfigurationProvider).FirstOrDefaultAsync (cancellationToken);

            if (entity == null) throw new NotFoundException ("Product", "Product not found");

            return entity;

        }
    }
}