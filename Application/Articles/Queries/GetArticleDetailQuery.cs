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
    public class GetArticleDetailQuery : IRequest<ArticlesDto> {
        public Guid Id { get; set; }
    }

    public class GetArticleQueryHandler : BaseCommandHandler<GetArticleQueryHandler>, IRequestHandler<GetArticleDetailQuery, ArticlesDto> {
        public GetArticleQueryHandler (IAppDbContext context, IMapper mapper, ILogger<GetArticleQueryHandler> logger) : base (context, mapper, logger) { }

        public async Task<ArticlesDto> Handle (GetArticleDetailQuery request, CancellationToken cancellationToken) {
            var entity = await Context.Articles.Where (x => x.IdArticle == request.Id).ProjectTo<ArticlesDto> (Mapper.ConfigurationProvider).FirstOrDefaultAsync (cancellationToken);

            if (entity == null) throw new NotFoundException ("Product", "Product not found");

            return entity;

        }
    }
}