using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Interface;
using Application.Common.Models;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Product.Commands.UpdateDealoftheDayCommands {
    public class RemoveDealoftheDayCommand : IRequest<string> {
        public List<Guid> IdProducts { get; set; }
    }

    public class RemoveDealoftheDayCommandHandler : BaseCommandHandler<RemoveDealoftheDayCommandHandler>, IRequestHandler<RemoveDealoftheDayCommand, string> {
        public RemoveDealoftheDayCommandHandler (IAppDbContext context, IMapper mapper, ILogger<RemoveDealoftheDayCommandHandler> logger) : base (context, mapper, logger) { }

        public async Task<string> Handle (RemoveDealoftheDayCommand request, CancellationToken cancellationToken) {
            var entity = Context.Products.Where (x => request.IdProducts.Contains (x.IdProduct)).ToList ();
            if (entity == null) throw new NotFoundException ("Products", "Not found!");

            entity.ForEach (x => x.IsDealoftheDay = false);

            await Context.SaveChangesAsync (true, cancellationToken);
            return "Sukses";
        }
    }
}