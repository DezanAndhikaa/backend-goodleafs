using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interface;
using Application.Common.Models;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Application.Categories.Commands.CreateCategoryCommands {
    public class CreateCategoryCommand : IRequest<string> {
        public Category Category { get; set; }
        public IFormFile Image { get; set; }
    }

    public class CreateCategoryCommandHandler : BaseCommandHandler<CreateCategoryCommandHandler>,
        IRequestHandler<CreateCategoryCommand, string> {
            public CreateCategoryCommandHandler (IAppDbContext context, IMapper mapper, ILogger<CreateCategoryCommandHandler> logger) : base (context, mapper, logger) { }

            public async Task<string> Handle (CreateCategoryCommand request, CancellationToken cancellationToken) {
                request.Category.IdCategory = Guid.NewGuid ();

                Random rnd = new Random ();

                string categoryName = request.Category.CategoryName.Replace (" ", String.Empty);
                var fileName = $"{categoryName}{rnd.Next(1,999)}{Path.GetExtension(request.Image.FileName)}";

                var path = Path.Combine ("./Resources/Category", fileName);

                using (var stream = System.IO.File.Create (path)) {
                    await request.Image.CopyToAsync (stream);
                }

                request.Category.ImageUrl = fileName;

                Context.Categories.Add (request.Category);
                await Context.SaveChangesAsync (true, cancellationToken);

                return "Sukses";
            }
        }

}