using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Interface;
using Application.Common.Models;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Couriers.Commands.UpdateCourierCommands {
    public class UpdateCourierCommand : IRequest<string> {
        public Courier Courier { get; set; }
    }

    public class UpdateCourierCommandHandler : BaseCommandHandler<UpdateCourierCommandHandler>, IRequestHandler<UpdateCourierCommand, string> {
        public UpdateCourierCommandHandler (IAppDbContext context, IMapper mapper, ILogger<UpdateCourierCommandHandler> logger) : base (context, mapper, logger) { }

        public async Task<string> Handle (UpdateCourierCommand request, CancellationToken cancellationToken) {
            var entity = Context.Couriers.Where (x => x.IdCourier == request.Courier.IdCourier).FirstOrDefault ();

            if (entity == null) throw new NotFoundException ("Courier", "Courier Not Found!");

            entity.CourierName = request.Courier.CourierName;
            entity.CourierArea = request.Courier.CourierArea;
            entity.CourierPhoneNumber = request.Courier.CourierPhoneNumber;
            entity.CourierPlateNumber = request.Courier.CourierPlateNumber;

            await Context.SaveChangesAsync (true, cancellationToken);
            return "Sukses";
        }
    }
}