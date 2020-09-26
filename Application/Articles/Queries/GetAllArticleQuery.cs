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
    public class GetAllArticleQuery : IRequest<ResponsesGetDto<ArticlesDto>> {
        public int Pagination { get; set; }
    }

    public class GetAllArticleQueryHandler : BaseCommandHandler<GetAllArticleQueryHandler>, IRequestHandler<GetAllArticleQuery, ResponsesGetDto<ArticlesDto>> {
        public GetAllArticleQueryHandler (IAppDbContext context, IMapper mapper, ILogger<GetAllArticleQueryHandler> logger) : base (context, mapper, logger) { }

        public async Task<ResponsesGetDto<ArticlesDto>> Handle (GetAllArticleQuery request, CancellationToken cancellationToken) {
            request.Pagination = request.Pagination == 0 ? 0 : request.Pagination;
            int skip = request.Pagination * Constant.DefaultPageSize;

            var totalData = Context.Articles.ToList ().Count;

            var entity = await Context.Articles.ProjectTo<ArticlesDto> (Mapper.ConfigurationProvider).ToListAsync (cancellationToken);

            entity = entity.Skip (skip).Take (Constant.DefaultPageSize).ToList ();
            var Responses = new ResponsesGetDto<ArticlesDto> (totalData, request.Pagination, entity);

            return Responses;
        }
    }
}