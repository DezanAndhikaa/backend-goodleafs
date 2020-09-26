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
    public class GetProductDetailQueryByName : IRequest<List<ProductsDto>> {
        public string NamaProduk { get; set; }
    }

    public class GetProductDetailQueryByNameHandler : BaseCommandHandler<GetProductDetailQueryByNameHandler>, IRequestHandler<GetProductDetailQueryByName, List<ProductsDto>> {
        public GetProductDetailQueryByNameHandler (IAppDbContext context, IMapper mapper, ILogger<GetProductDetailQueryByNameHandler> logger) : base (context, mapper, logger) { }

        public async Task<List<ProductsDto>> Handle (GetProductDetailQueryByName request, CancellationToken cancellationToken) {

            var entity = await Context.Products.Where (x => x.ProductName.Contains (request.NamaProduk)).ProjectTo<ProductsDto> (Mapper.ConfigurationProvider).ToListAsync (cancellationToken);

            if (entity == null) throw new NotFoundException ("Product", "Product not found");

            return entity;

        }
    }
}