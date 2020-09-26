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
    public class GetCategoryDetailQueryByName : IRequest<List<CategoryDto>> {
        public string Name { get; set; }
    }

    public class GetCategoryDetailQueryByNameHandler : BaseCommandHandler<GetCategoryDetailQueryByNameHandler>, IRequestHandler<GetCategoryDetailQueryByName, List<CategoryDto>> {
        public GetCategoryDetailQueryByNameHandler (IAppDbContext context, IMapper mapper, ILogger<GetCategoryDetailQueryByNameHandler> logger) : base (context, mapper, logger) { }

        public async Task<List<CategoryDto>> Handle (GetCategoryDetailQueryByName request, CancellationToken cancellationToken) {

            var entity = await Context.Categories.Where (x => x.CategoryName.Contains (request.Name)).ProjectTo<CategoryDto> (Mapper.ConfigurationProvider).ToListAsync (cancellationToken);

            if (entity == null) throw new NotFoundException ("Product", "Product not found");

            return entity;

        }
    }
}