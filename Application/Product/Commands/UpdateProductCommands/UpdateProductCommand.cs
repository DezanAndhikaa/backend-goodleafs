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
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Application.Product.Commands.UpdateProductCommands {
    public class UpdateProductCommand : IRequest<string> {
        public ProductRequestUpdateDto Product { get; set; }
        public IFormFile Image { get; set; }
    }

    public class UpdateProductCommandHandler : BaseCommandHandler<UpdateProductCommandHandler>, IRequestHandler<UpdateProductCommand, string> {
        public UpdateProductCommandHandler (IAppDbContext context, IMapper mapper, ILogger<UpdateProductCommandHandler> logger) : base (context, mapper, logger) { }

        public async Task<string> Handle (UpdateProductCommand request, CancellationToken cancellationToken) {
            Random rnd = new Random ();
            var entity = Context.Products.Where (x => x.IdProduct == request.Product.IdProduct).FirstOrDefault ();

            if (entity == null) throw new NotFoundException ("Product", "Not found!");

            entity.IsAvailable = request.Product.IsAvailable;
            entity.ProductName = request.Product.ProductName;
            entity.Stock = request.Product.Stock;
            entity.VariantName = request.Product.VariantName;
            entity.BaseColor = request.Product.BaseColor;
            entity.CategoryName = request.Product.CategoryName;
            entity.Cost = request.Product.Cost;
            entity.Description = request.Product.Description;

            if (request.Image != null) {
                try {
                    File.Delete (Path.Combine ("./Resources/Products", entity.ImageUrl));
                } catch (Exception e) {
                    Logger.LogError ($"Error when delete file : {e}");
                }

                try {
                    string productName = request.Product.ProductName.Replace (" ", String.Empty);
                    var fileName = $"{productName}{rnd.Next(1,999)}{Path.GetExtension(request.Image.FileName)}";
                    var path = Path.Combine ("./Resources/Products", fileName);

                    using (var stream = System.IO.File.Create (path)) {
                        await request.Image.CopyToAsync (stream);
                    }
                    entity.ImageUrl = fileName;
                } catch (Exception e) {
                    Logger.LogError ($"Error when moving file : {e}");

                }
            }

            await Context.SaveChangesAsync (true, cancellationToken);
            return "Sukses";
        }
    }
}