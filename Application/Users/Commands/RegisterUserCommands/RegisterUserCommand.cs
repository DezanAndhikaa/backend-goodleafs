using System;
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
using Microsoft.Extensions.Logging;

namespace Application.Users.Commands.RegisterUserCommands {
    public class RegisterUserCommand : UserRegisterDto, IRequest<string> {

    }

    public class RegisterUserCommandHandler : BaseCommandHandler<RegisterUserCommandHandler>,
        IRequestHandler<RegisterUserCommand, string> {
            public RegisterUserCommandHandler (IAppDbContext context, IMapper mapper, ILogger<RegisterUserCommandHandler> logger) : base (context, mapper, logger) { }

            public async Task<string> Handle (RegisterUserCommand request, CancellationToken cancellationToken) {

                var checker = Context.Users.Where (x => x.Email == request.Email).Count ();
                if (checker > 0) throw new BadRequestException ("Email sudah terdaftar");

                var newUser = new User {
                    UserId = Guid.NewGuid (),
                    Address = "-",
                    Birthday = "-",
                    Email = request.Email,
                    Name = request.Name,
                    Password = request.Password,
                    Gender = 3,
                    Hobby = "-",
                    ImageUrl = "-",
                    Phone = "-",
                    TotalOrder = 0
                };

                Context.Users.Add (newUser);
                await Context.SaveChangesAsync (true, cancellationToken);

                return "Sukses";
            }
        }

}