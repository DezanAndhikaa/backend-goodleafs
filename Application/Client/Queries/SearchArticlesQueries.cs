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

namespace Application.Client.Queries {
    public class SearchArticlesQueries : IRequest<ArticlesDto> {
        public Guid IdArticle { get; set; }
    }

    public class SearchArticlesQueriesHandler : BaseCommandHandler<SearchArticlesQueriesHandler>, IRequestHandler<SearchArticlesQueries, ArticlesDto> {
        public SearchArticlesQueriesHandler (IAppDbContext context, IMapper mapper, ILogger<SearchArticlesQueriesHandler> logger) : base (context, mapper, logger) { }

        public async Task<ArticlesDto> Handle (SearchArticlesQueries request, CancellationToken cancellationToken) {
            var entiy = await Context.Articles.Where (x => x.IdArticle == request.IdArticle).ProjectTo<ArticlesDto> (Mapper.ConfigurationProvider).FirstOrDefaultAsync (cancellationToken);
            if (entiy == null) throw new NotFoundException ("Articles", "Not found!");

            return entiy;
        }
    }
}