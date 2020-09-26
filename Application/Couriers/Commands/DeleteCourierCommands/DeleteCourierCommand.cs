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

namespace Application.Couriers.Commands.DeleteCourierCommands {
    public class DeleteCourierCommand : IRequest<string> {
        public Guid Id { get; set; }
    }

    public class DeleteCourierCommandHandler : BaseCommandHandler<DeleteCourierCommandHandler>, IRequestHandler<DeleteCourierCommand, string> {
        public DeleteCourierCommandHandler (IAppDbContext context, IMapper mapper, ILogger<DeleteCourierCommandHandler> logger) : base (context, mapper, logger) { }

        public async Task<string> Handle (DeleteCourierCommand request, CancellationToken cancellationToken) {
            var entity = Context.Couriers.Where (x => x.IdCourier == request.Id).FirstOrDefault ();

            if (entity == null) throw new NotFoundException ("Category", "Category not found!");

            Context.Couriers.Remove (entity);
            await Context.SaveChangesAsync (true, cancellationToken);

            return "Sukses";
        }
    }
}