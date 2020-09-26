using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interface;
using Application.Common.Models;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Application.Users.Commands.CreateUserCommands {
    public class CreateUserCommand : IRequest<string> {
        public User User { get; set; }
        public IFormFile Image { get; set; }
    }

    public class CreateUserCommandHandler : BaseCommandHandler<CreateUserCommandHandler>,
        IRequestHandler<CreateUserCommand, string> {
            public CreateUserCommandHandler (IAppDbContext context, IMapper mapper, ILogger<CreateUserCommandHandler> logger) : base (context, mapper, logger) { }
            private static Random random = new Random ();

            public async Task<string> Handle (CreateUserCommand request, CancellationToken cancellationToken) {
                request.User.UserId = Guid.NewGuid ();

                var fileName = $"{RandomString(6)}{random.Next(1,999)}{Path.GetExtension(request.Image.FileName)}";

                var path = Path.Combine ("./Resources/User", fileName);

                using (var stream = System.IO.File.Create (path)) {
                    await request.Image.CopyToAsync (stream);
                }

                request.User.ImageUrl = fileName;

                Context.Users.Add (request.User);

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