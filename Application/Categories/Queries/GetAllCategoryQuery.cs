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
    public class GetAllCategoryQuery : IRequest<ResponsesGetDto<CategoryDto>> {
        public int Pagination { get; set; }
    }

    public class GetAllCategoryQueryHandler : BaseCommandHandler<GetAllCategoryQueryHandler>, IRequestHandler<GetAllCategoryQuery, ResponsesGetDto<CategoryDto>> {
        public GetAllCategoryQueryHandler (IAppDbContext context, IMapper mapper, ILogger<GetAllCategoryQueryHandler> logger) : base (context, mapper, logger) { }

        public async Task<ResponsesGetDto<CategoryDto>> Handle (GetAllCategoryQuery request, CancellationToken cancellationToken) {
            request.Pagination = request.Pagination == 0 ? 0 : request.Pagination;
            int skip = request.Pagination * Constant.DefaultPageSize;

            var totalData = Context.Categories.ToList ().Count;

            var entity = await Context.Categories.ProjectTo<CategoryDto> (Mapper.ConfigurationProvider).ToListAsync (cancellationToken);

            entity = entity.Skip (skip).Take (Constant.DefaultPageSize).ToList ();
            var Responses = new ResponsesGetDto<CategoryDto> (totalData, request.Pagination, entity);

            return Responses;
        }
    }
}