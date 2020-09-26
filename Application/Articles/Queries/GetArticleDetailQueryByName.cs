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
    public class GetArticleDetailQueryByName : IRequest<List<ArticlesDto>> {
        public string Name { get; set; }
    }

    public class GetArticleDetailQueryByNameHandler : BaseCommandHandler<GetArticleDetailQueryByNameHandler>, IRequestHandler<GetArticleDetailQueryByName, List<ArticlesDto>> {
        public GetArticleDetailQueryByNameHandler (IAppDbContext context, IMapper mapper, ILogger<GetArticleDetailQueryByNameHandler> logger) : base (context, mapper, logger) { }

        public async Task<List<ArticlesDto>> Handle (GetArticleDetailQueryByName request, CancellationToken cancellationToken) {

            var entity = await Context.Articles.Where (x => x.ArticleTitle.Contains (request.Name)).ProjectTo<ArticlesDto> (Mapper.ConfigurationProvider).ToListAsync (cancellationToken);

            if (entity == null) throw new NotFoundException ("Product", "Product not found");

            return entity;

        }
    }
}