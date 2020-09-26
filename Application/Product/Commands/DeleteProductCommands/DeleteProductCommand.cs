using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Interface;
using Application.Common.Models;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Application.Product.Commands.DeleteProductCommands {
    public class DeleteProductCommand : IRequest<string> {
        public Guid IdProduct { get; set; }
    }

    public class DeleteProductCommandHandler : BaseCommandHandler<DeleteProductCommandHandler>, IRequestHandler<DeleteProductCommand, string> {
        public DeleteProductCommandHandler (IAppDbContext context, IMapper mapper, ILogger<DeleteProductCommandHandler> logger) : base (context, mapper, logger) { }

        public async Task<string> Handle (DeleteProductCommand request, CancellationToken cancellationToken) {
            var entity = await Context.Products.FirstOrDefaultAsync (cancellationToken);

            if (entity == null) throw new NotFoundException ("Product", "Product not found!");

            Context.Products.Remove (entity);
            await Context.SaveChangesAsync (true, cancellationToken);
            return "Sukses";
        }
    }
}