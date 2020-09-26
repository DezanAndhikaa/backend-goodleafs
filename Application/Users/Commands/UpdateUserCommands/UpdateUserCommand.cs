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

namespace Application.Users.Commands.UpdateUserCommands {
    public class UpdateUserCommand : IRequest<string> {
        public User User { get; set; }
        public IFormFile Image { get; set; }
    }

    public class UpdateUserCommandHandler : BaseCommandHandler<UpdateUserCommandHandler>, IRequestHandler<UpdateUserCommand, string> {
        public UpdateUserCommandHandler (IAppDbContext context, IMapper mapper, ILogger<UpdateUserCommandHandler> logger) : base (context, mapper, logger) { }
        private static Random random = new Random ();

        public async Task<string> Handle (UpdateUserCommand request, CancellationToken cancellationToken) {
            var entity = Context.Users.Where (x => x.UserId == request.User.UserId).FirstOrDefault ();

            if (entity == null) throw new NotFoundException ("User", "User Not Found!");

            entity.Address = request.User.Address;
            entity.Birthday = request.User.Birthday;
            entity.Gender = request.User.Gender;
            entity.Hobby = request.User.Hobby;
            entity.Name = request.User.Name;
            entity.Password = request.User.Password;
            entity.Phone = request.User.Phone;
            entity.ZipCode = request.User.ZipCode;

            if (request.Image != null) {
                try {
                    File.Delete (Path.Combine ("./Resources/Discounts", entity.ImageUrl));
                } catch (Exception e) {
                    Logger.LogError ($"Error when delete file : {e}");
                }

                try {
                    var fileName = $"{RandomString(6)}{random.Next(1,999)}{Path.GetExtension(request.Image.FileName)}";
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
        public static string RandomString (int length) {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string (Enumerable.Repeat (chars, length)
                .Select (s => s[random.Next (s.Length)]).ToArray ());
        }
    }
}