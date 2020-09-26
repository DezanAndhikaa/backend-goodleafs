using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Dtos;
using Application.Common.Exceptions;
using Application.Common.Interface;
using Application.Common.Models;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Application.Discounts.Commands.UpdateDiscountCommands {
    public class UpdateDiscountCommand : IRequest<string> {
        public DiscountDto DiscountDto { get; set; }
        public IFormFile DiscountBanner { get; set; }
    }

    public class UpdateDiscountCommandHandler : BaseCommandHandler<UpdateDiscountCommandHandler>, IRequestHandler<UpdateDiscountCommand, string> {
        public UpdateDiscountCommandHandler (IAppDbContext context, IMapper mapper, ILogger<UpdateDiscountCommandHandler> logger) : base (context, mapper, logger) { }
        private static Random random = new Random ();

        public async Task<string> Handle (UpdateDiscountCommand request, CancellationToken cancellationToken) {
            var entity = Context.Discounts.Where (x => x.IdDiscount == request.DiscountDto.IdDiscount).FirstOrDefault ();

            if (entity == null) throw new NotFoundException ("Courier", "Courier Not Found!");

            entity.Content = request.DiscountDto.Content;
            entity.DiscountName = request.DiscountDto.DiscountName;
            entity.DiscountStart = request.DiscountDto.DiscountStart;
            entity.DiscountType = request.DiscountDto.DiscountType;
            entity.DiscountEnd = request.DiscountDto.DiscountEnd;
            entity.Voucher = request.DiscountDto.Voucher;
            entity.Items = request.DiscountDto.Items;

            if (request.DiscountBanner != null) {
                try {
                    File.Delete (Path.Combine ("./Resources/Discounts", entity.DiscountBanner));
                } catch (Exception e) {
                    Logger.LogError ($"Error when delete file : {e}");
                }

                try {
                    var fileName = $"{RandomString(6)}{random.Next(1,999)}{Path.GetExtension(request.DiscountBanner.FileName)}";
                    var path = Path.Combine ("./Resources/Discounts", fileName);

                    using (var stream = System.IO.File.Create (path)) {
                        await request.DiscountBanner.CopyToAsync (stream);
                    }
                    entity.DiscountBanner = fileName;
                } catch (Exception e) {
                    Logger.LogError ($"Error when moving file : {e}");
                }
            }

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