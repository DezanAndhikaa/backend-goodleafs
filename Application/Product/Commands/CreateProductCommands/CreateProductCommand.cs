using System;
using System.IO;
using System.Net.Http;
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

namespace Application.Product.Commands.CreateProductCommands {
    public class CreateProductCommand : IRequest<string> {
        public ProductRequestDto Product { get; set; }
        public IFormFile Image { get; set; }

        public class CreateProductCommandHandler : BaseCommandHandler<CreateProductCommandHandler>,
        IRequestHandler<CreateProductCommand, string> {
            public CreateProductCommandHandler (IAppDbContext context, IMapper mapper, ILogger<CreateProductCommandHandler> logger) : base (context, mapper, logger) { }

            public async Task<string> Handle (CreateProductCommand request, CancellationToken cancellationToken) {
                Logger.LogInformation ($"Creating Product Commands...");

                var newProduk = new ProductGL {
                    IdProduct = Guid.NewGuid (),
                    BaseColor = request.Product.BaseColor,
                    CategoryName = request.Product.CategoryName,
                    ConstAmount = 0,
                    Cost = request.Product.Cost,
                    Description = request.Product.Description,
                    IsAvailable = request.Product.IsAvailable,
                    ProductName = request.Product.ProductName,
                    Stock = request.Product.Stock,
                    VariantName = request.Product.VariantName,
                    IsDealoftheDay = false
                };

                Random rnd = new Random ();

                string productName = request.Product.ProductName.Replace (" ", String.Empty);
                var fileName = $"{productName}{rnd.Next(1,999)}{Path.GetExtension(request.Image.FileName)}";

                var path = Path.Combine ("./Resources/Products", fileName);

                using (var stream = System.IO.File.Create (path)) {
                    await request.Image.CopyToAsync (stream);
                }

                newProduk.ImageUrl = fileName;

                Context.Products.Add (newProduk);
                await Context.SaveChangesAsync (true, cancellationToken);
                return "Sukses";
            }
        }

    }
}