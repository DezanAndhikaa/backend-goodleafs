using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Dtos;
using Application.Common.Interface;
using Application.Common.Models;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Application.Discounts.Commands.CreateDiscountCommands {
    public class CreateDiscountCommand : IRequest<string> {
        public DiscountDto DiscountDto { get; set; }
        public IFormFile DiscountBanner { get; set; }
    }

    public class CreateDiscountCommandHandler : BaseCommandHandler<CreateDiscountCommandHandler>,
        IRequestHandler<CreateDiscountCommand, string> {
            public CreateDiscountCommandHandler (IAppDbContext context, IMapper mapper, ILogger<CreateDiscountCommandHandler> logger) : base (context, mapper, logger) { }
            private static Random random = new Random ();

            public async Task<string> Handle (CreateDiscountCommand request, CancellationToken cancellationToken) {
                var newDiscount = new Discount {
                    IdDiscount = Guid.NewGuid (),
                    Content = request.DiscountDto.Content,
                    DiscountEnd = request.DiscountDto.DiscountEnd,
                    DiscountStart = request.DiscountDto.DiscountStart,
                    DiscountName = request.DiscountDto.DiscountName,
                    DiscountType = request.DiscountDto.DiscountType,
                    Items = request.DiscountDto.Items,
                };

                if (request.DiscountDto.Voucher != null || request.DiscountDto.Voucher == "") {
                    newDiscount.Voucher = RandomString (5);
                } else {
                    newDiscount.Voucher = request.DiscountDto.Voucher;
                }

                var fileName = $"{RandomString(6)}{random.Next(1,999)}{Path.GetExtension(request.DiscountBanner.FileName)}";

                var path = Path.Combine ("./Resources/Discounts", fileName);

                using (var stream = System.IO.File.Create (path)) {
                    await request.DiscountBanner.CopyToAsync (stream);
                }

                newDiscount.DiscountBanner = fileName;

                Context.Discounts.Add (newDiscount);

                await Context.SaveChangesAsync (true, cancellationToken);

                return "Sukses";
            }

            public static string RandomString (int length) {
                const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
                return new string (Enumerable.Repeat (chars, length)
                    .Select (s => s[random.Next (s.Length)]).ToArray ());
            }
        }

}