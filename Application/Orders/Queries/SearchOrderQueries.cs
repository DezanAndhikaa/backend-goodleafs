using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Dtos;
using Application.Common.Interface;
using Application.Common.Models;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Application.Orders.Queries {
    public class SearchOrderQueries : IRequest<List<DetailOrderDataDto>> {
        public int StatusOrder { get; set; }
    }

    public class SearchOrderQueriesHandler : BaseCommandHandler<SearchOrderQueries>, IRequestHandler<SearchOrderQueries, List<DetailOrderDataDto>> {
        public SearchOrderQueriesHandler (IAppDbContext context, IMapper mapper, ILogger<SearchOrderQueries> logger) : base (context, mapper, logger) { }

        public async Task<List<DetailOrderDataDto>> Handle (SearchOrderQueries request, CancellationToken cancellationToken) {
            List<DetailOrderDataDto> ListDetailOrder = new List<DetailOrderDataDto> ();
            var entityOrder = await Context.Orders.Where (x => x.StatusOrder == request.StatusOrder).ToListAsync (cancellationToken);

            foreach (var data in entityOrder) {
                var entity = new DetailOrderDataDto ();
                entity.ListProducts = new List<DetailProductOrderDto> ();

                entity.IdOrder = data.IdOrder;

                var courier = Context.Couriers.Where (x => x.IdCourier == data.IdCourier).Select (y => y.CourierName).FirstOrDefault ();

                entity.IdCourier = data.IdCourier;
                entity.NamaCourier = courier;
                entity.StatusOrder = data.StatusOrder;
                entity.TanggalOrder = data.TanggalOrder;
                entity.EmailUser = data.EmailUser;

                var detailOrderList = Context.DetailOrders.Where (x => x.IdOrder == data.IdOrder).Select (b => new {b.TotalProducts, b.IdProducts}).ToList ();

                foreach (var value in detailOrderList) {
                    var fetchDetailProduct = Context.Products.Where (a => a.IdProduct == value.IdProducts).Select (c => c.ProductName).FirstOrDefault ();

                    if (fetchDetailProduct != null) {
                        entity.ListProducts.Add (new DetailProductOrderDto {
                            IdProducts = value.IdProducts,
                                ProductName = fetchDetailProduct,
                                TotalProducts = value.TotalProducts,
                        });
                    }
                }
                ListDetailOrder.Add (entity);
            }

            return ListDetailOrder;

        }
    }
}