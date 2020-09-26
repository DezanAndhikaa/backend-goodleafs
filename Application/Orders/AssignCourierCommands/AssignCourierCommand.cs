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

namespace Application.Orders.AssignCourierCommands {
    public class AssignCourierCommand : IRequest<string> {
        public Guid IdOrder { get; set; }
        public Guid IdCourier { get; set; }
    }

    public class AssignCourierCommandHandler : BaseCommandHandler<AssignCourierCommandHandler>, IRequestHandler<AssignCourierCommand, string> {
        public AssignCourierCommandHandler (IAppDbContext context, IMapper mapper, ILogger<AssignCourierCommandHandler> logger) : base (context, mapper, logger) { }

        public async Task<string> Handle (AssignCourierCommand request, CancellationToken cancellationToken) {
            var entity = Context.Orders.Where (x => x.IdOrder == request.IdOrder).FirstOrDefault ();

            if (entity == null) throw new BadRequestException ("Id Order was invalid");

            if (entity.StatusOrder == 2) throw new BadRequestException ("Can't assign courier because order is on the way with other couriers");
            if (entity.StatusOrder == 3) throw new BadRequestException ("Can't assign courier because order is complete");
            if (entity.StatusOrder == 0) throw new BadRequestException ("Can't assign courier because order is not approved");

            entity.IdCourier = request.IdCourier;
            await Context.SaveChangesAsync (true, cancellationToken);
            return "Sukses";
        }
    }
}