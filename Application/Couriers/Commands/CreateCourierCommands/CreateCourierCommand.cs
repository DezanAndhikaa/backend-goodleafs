using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interface;
using Application.Common.Models;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Couriers.Commands.CreateCourierCommands {
    public class CreateCourierCommand : IRequest<string> {
        public Courier Courier { get; set; }
    }

    public class CreateCourierCommandHandler : BaseCommandHandler<CreateCourierCommandHandler>,
        IRequestHandler<CreateCourierCommand, string> {
            public CreateCourierCommandHandler (IAppDbContext context, IMapper mapper, ILogger<CreateCourierCommandHandler> logger) : base (context, mapper, logger) { }

            public async Task<string> Handle (CreateCourierCommand request, CancellationToken cancellationToken) {
                request.Courier.IdCourier = Guid.NewGuid ();
                request.Courier.CourierStatus = 0;
                Context.Couriers.Add (request.Courier);

                await Context.SaveChangesAsync (true, cancellationToken);

                return "Sukses";
            }
        }

}