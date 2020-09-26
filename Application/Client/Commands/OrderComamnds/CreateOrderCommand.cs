using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Dtos;
using Application.Common.Interface;
using Application.Common.Models;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Client.Commands.OrderComamnds {
    public class CreateOrderCommand : IRequest<string> {
        public string EmailUser { get; set; }
        public List<OrderCustomerDto> IdProducts { get; set; }
    }

    public class CreateOrderCommandHandler : BaseCommandHandler<CreateOrderCommandHandler>, IRequestHandler<CreateOrderCommand, string> {
        public CreateOrderCommandHandler (IAppDbContext context, IMapper mapper, ILogger<CreateOrderCommandHandler> logger) : base (context, mapper, logger) { }

        public async Task<string> Handle (CreateOrderCommand request, CancellationToken cancellationToken) {
            var idOrder = Guid.NewGuid ();
            var entityOrder = new Order {
                EmailUser = request.EmailUser,
                StatusOrder = 0,
                IdOrder = idOrder,
                TanggalOrder = DateTime.Now,
            };
            Context.Orders.Add (entityOrder);

            List<DetailOrder> records = new List<DetailOrder> ();

            foreach (var data in request.IdProducts) {
                var newRecord = new DetailOrder {
                    IdDetailOrder = Guid.NewGuid (),
                    IdOrder = idOrder,
                    IdProducts = data.IdProducts,
                    TotalProducts = data.TotalProducts
                };

                var entity = Context.Products.Where (x => x.IdProduct == data.IdProducts).FirstOrDefault ();

                entity.Stock = entity.Stock - data.TotalProducts;

                records.Add (newRecord);
            }

            await Context.DetailOrders.AddRangeAsync (records, cancellationToken);
            await Context.SaveChangesAsync (true, cancellationToken);
            return "Sukses";

        }
    }
}