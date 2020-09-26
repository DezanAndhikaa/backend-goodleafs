using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Interface;
using Application.Common.Models;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Application.Categories.Commands.UpdateCategoryCommands {
    public class UpdateCategoryCommand : IRequest<string> {
        public Category Category { get; set; }
        public IFormFile ImageUrl { get; set; }
    }

    public class UpdateCategoryCommandHandler : BaseCommandHandler<UpdateCategoryCommandHandler>, IRequestHandler<UpdateCategoryCommand, string> {
        public UpdateCategoryCommandHandler (IAppDbContext context, IMapper mapper, ILogger<UpdateCategoryCommandHandler> logger) : base (context, mapper, logger) { }

        public async Task<string> Handle (UpdateCategoryCommand request, CancellationToken cancellationToken) {
            var entity = Context.Categories.Where (x => x.IdCategory == request.Category.IdCategory).FirstOrDefault ();
            Random rnd = new Random ();

            if (entity == null) throw new NotFoundException ("Article", "Article Not Found!");

            entity.CategoryName = request.Category.CategoryName;

            if (request.ImageUrl != null) {
                try {
                    File.Delete (Path.Combine ("./Resources/Products", entity.ImageUrl));
                } catch (Exception e) {
                    Logger.LogError ($"Error when delete file : {e}");
                }

                try {
                    string categoryName = request.Category.CategoryName.Replace (" ", String.Empty);
                    var fileName = $"{categoryName}{rnd.Next(1,999)}{Path.GetExtension(request.ImageUrl.FileName)}";
                    var path = Path.Combine ("./Resources/Products", fileName);

                    using (var stream = System.IO.File.Create (path)) {
                        await request.ImageUrl.CopyToAsync (stream);
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