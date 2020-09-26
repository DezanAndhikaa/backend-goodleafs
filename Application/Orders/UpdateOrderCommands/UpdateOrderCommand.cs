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

namespace Application.Orders.UpdateOrderCommands {
    public class UpdateOrderCommand : IRequest<string> {
        public Guid IdOrder { get; set; }
        public int StatusOrder { get; set; }
    }

    public class UpdateOrderCommandHandler : BaseCommandHandler<UpdateOrderCommand>, IRequestHandler<UpdateOrderCommand, string> {
        public UpdateOrderCommandHandler (IAppDbContext context, IMapper mapper, ILogger<UpdateOrderCommand> logger) : base (context, mapper, logger) { }

        public async Task<string> Handle (UpdateOrderCommand request, CancellationToken cancellationToken) {
            var entity = Context.Orders.Where (x => x.IdOrder == request.IdOrder).FirstOrDefault ();

            if (entity == null) throw new BadRequestException ("IdOrder was invalid");

            if (entity.StatusOrder == 3) throw new BadRequestException ("Order already complete!");

            entity.StatusOrder = request.StatusOrder;
            await Context.SaveChangesAsync (true, cancellationToken);

            return "Sukses";
        }
    }
}