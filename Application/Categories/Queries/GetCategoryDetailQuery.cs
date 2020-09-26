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

namespace Application.Categories.Queries {
    public class GetCategoryDetailQuery : IRequest<CategoryDto> {
        public Guid Id { get; set; }
    }

    public class GetCategoryDetailQueryHandler : BaseCommandHandler<GetCategoryDetailQueryHandler>, IRequestHandler<GetCategoryDetailQuery, CategoryDto> {
        public GetCategoryDetailQueryHandler (IAppDbContext context, IMapper mapper, ILogger<GetCategoryDetailQueryHandler> logger) : base (context, mapper, logger) { }

        public async Task<CategoryDto> Handle (GetCategoryDetailQuery request, CancellationToken cancellationToken) {
            var entity = await Context.Categories.Where (x => x.IdCategory == request.Id).ProjectTo<CategoryDto> (Mapper.ConfigurationProvider).FirstOrDefaultAsync (cancellationToken);

            if (entity == null) throw new NotFoundException ("Product", "Product not found");

            return entity;

        }
    }
}