using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Dtos;
using Application.Common.Models;
using Application.Common.Vm;
using Application.Users.Commands.CreateUserCommands;
using Application.Users.Commands.DeleteUserCommands;
using Application.Users.Commands.UpdateUserCommands;
using Application.Users.Queries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Api.Controllers {

    [Route ("api/[controller]")]
    public class UserController : BaseController<UserController> {
        public UserController (ILogger<UserController> logger) : base (logger) { }

        [HttpPost]
        [Produces ("application/json")]
        [ProducesResponseType (typeof (string), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<string>> CreateUser ([FromForm] FormUserVm command, CancellationToken cancellationToken) {
            return Ok (await Mediator.Send (new CreateUserCommand { Image = command.UserProfile, User = command.User }, cancellationToken));
        }

        [HttpGet ("details/{id}")]
        [Produces ("application/json")]
        [ProducesResponseType (typeof (UserDto), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<UserDto>> SearchUser (Guid id, CancellationToken cancellationToken) {
            return Ok (await Mediator.Send (new GetUserDetailQuery { Id = id }, cancellationToken));
        }

        [HttpGet ("search/{name}")]
        [Produces ("application/json")]
        [ProducesResponseType (typeof (List<UserDto>), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<List<UserDto>>> SearchUserByName (string name, CancellationToken cancellationToken) {
            return Ok (await Mediator.Send (new GetUserDetailQueryByName { Name = name }, cancellationToken));
        }

        [HttpGet]
        [Produces ("application/json")]
        [ProducesResponseType (typeof (ResponsesGetDto<UserDto>), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<ResponsesGetDto<UserDto>>> AllUser ([FromQuery] FromQueryModel queryModel, CancellationToken cancellationToken) {
            return Ok (await Mediator.Send (new GetAllUserQuery { Pagination = queryModel.Pagination }, cancellationToken));
        }

        [HttpPut]
        [Produces ("application/json")]
        [ProducesResponseType (typeof (string), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<string>> UpdateUser ([FromForm] FormUserVm command, CancellationToken cancellationToken) {
            return Ok (await Mediator.Send (new UpdateUserCommand { User = command.User, Image = command.UserProfile }, cancellationToken));
        }

        [HttpDelete ("{id}")]
        [Produces ("application/json")]
        [ProducesResponseType (typeof (string), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<string>> DeleteUser (Guid id, CancellationToken cancellationToken) {
            return Ok (await Mediator.Send (new DeleteUserCommand { Id = id }, cancellationToken));
        }
    }
}