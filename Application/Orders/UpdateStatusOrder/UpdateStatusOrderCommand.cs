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

namespace Application.Orders.UpdateStatusOrder
{
    public class UpdateStatusOrderCommand : IRequest<string>
    {
        public Guid IdOrder {get;set;}
        public int StatusOrder {get; set;}
    }

    public class UpdateStatusOrderCommandHandler : BaseCommandHandler<UpdateStatusOrderCommandHandler>, IRequestHandler<UpdateStatusOrderCommand, string>
    {
        public UpdateStatusOrderCommandHandler(IAppDbContext context, IMapper mapper, ILogger<UpdateStatusOrderCommandHandler> logger) : base(context, mapper, logger)
        {
        }

        public async Task<string> Handle(UpdateStatusOrderCommand request, CancellationToken cancellationToken)
        {
            var entity = Context.Orders.Where(x=> x.IdOrder == request.IdOrder).FirstOrDefault();

            if(entity == null) throw new BadRequestException("Order not found");

            entity.StatusOrder = request.StatusOrder;

           await Context.SaveChangesAsync(true, cancellationToken);

            return "Sukses";
        }
    }
}