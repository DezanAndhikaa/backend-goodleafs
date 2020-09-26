using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Interface;
using Application.Common.Models;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Discounts.Commands.DeleteDiscountCommands {
    public class DeleteDiscountCommand : IRequest<string> {
        public Guid Id { get; set; }
    }

    public class DeleteDiscountCommandHandler : BaseCommandHandler<DeleteDiscountCommandHandler>, IRequestHandler<DeleteDiscountCommand, string> {
        public DeleteDiscountCommandHandler (IAppDbContext context, IMapper mapper, ILogger<DeleteDiscountCommandHandler> logger) : base (context, mapper, logger) { }

        public async Task<string> Handle (DeleteDiscountCommand request, CancellationToken cancellationToken) {
            var entity = Context.Discounts.Where (x => x.IdDiscount == request.Id).FirstOrDefault ();

            if (entity == null) throw new NotFoundException ("Category", "Category not found!");

            Context.Discounts.Remove (entity);
            await Context.SaveChangesAsync (true, cancellationToken);

            return "Sukses";
        }
    }
}