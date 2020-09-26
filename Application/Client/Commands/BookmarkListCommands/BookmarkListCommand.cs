using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Dtos;
using Application.Common.Interface;
using Application.Common.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Application.Client.Commands.BookmarkListCommands {
    public class BookmarkListCommand : IRequest<List<ProductsDto>> {
        public List<Guid> IdProducts { get; set; }
    }

    public class BookmarkListCommandHandler : BaseCommandHandler<BookmarkListCommandHandler>, IRequestHandler<BookmarkListCommand, List<ProductsDto>> {
        public BookmarkListCommandHandler (IAppDbContext context, IMapper mapper, ILogger<BookmarkListCommandHandler> logger) : base (context, mapper, logger) { }

        public async Task<List<ProductsDto>> Handle (BookmarkListCommand request, CancellationToken cancellationToken) {
            var entity = await Context.Products.Where (x => request.IdProducts.Contains (x.IdProduct)).ProjectTo<ProductsDto> (Mapper.ConfigurationProvider).ToListAsync (cancellationToken);

            return entity;
        }
    }
}