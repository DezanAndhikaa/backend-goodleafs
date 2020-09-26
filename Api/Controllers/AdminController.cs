using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Admins.Commands.CreateAdminCommands;
using Application.Admins.Commands.DeleteAdminCommands;
using Application.Admins.Commands.LoginAdminCommands;
using Application.Admins.Commands.UpdateAdminCommands;
using Application.Admins.Queries;
using Application.Articles.Commands.CreateArticleCommands;
using Application.Articles.Commands.DeleteArticleCommands;
using Application.Articles.Commands.UpdateArticleCommands;
using Application.Common.Dtos;
using Application.Common.Models;
using Application.Product.Queries;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Api.Controllers {

    [Route ("api/[controller]")]
    public class AdminController : BaseController<AdminController> {
        public AdminController (ILogger<AdminController> logger) : base (logger) { }

        [HttpPost]
        [Produces ("application/json")]
        [ProducesResponseType (typeof (string), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<string>> CreateAdmin (CreateAdminCommand command, CancellationToken cancellationToken) {
            return Ok (await Mediator.Send (command, cancellationToken));
        }

        [HttpPost ("login")]
        [Produces ("application/json")]
        [ProducesResponseType (typeof (string), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<string>> LoginAdmin (LoginAdmminCommand command, CancellationToken cancellationToken) {
            return Ok (await Mediator.Send (command, cancellationToken));
        }

        [HttpGet ("search/{username}")]
        [Produces ("application/json")]
        [ProducesResponseType (typeof (AdminDto), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<AdminDto>> SearchAdminByName (string username, CancellationToken cancellationToken) {
            return Ok (await Mediator.Send (new GetAdminDetailQuery { Username = username }, cancellationToken));
        }

        [HttpGet]
        [Produces ("application/json")]
        [ProducesResponseType (typeof (ResponsesGetDto<AdminDto>), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<ResponsesGetDto<AdminDto>>> AllData ([FromQuery] FromQueryModel queryModel, CancellationToken cancellationToken) {
            return Ok (await Mediator.Send (new GetAllAdminQuery { Pagination = queryModel.Pagination }, cancellationToken));
        }

        [HttpPut]
        [Produces ("application/json")]
        [ProducesResponseType (typeof (string), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<string>> Update (UpdateAdminCommand command, CancellationToken cancellationToken) {
            return Ok (await Mediator.Send (command, cancellationToken));
        }

        [HttpDelete ("{username}")]
        [Produces ("application/json")]
        [ProducesResponseType (typeof (string), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<string>> Delete (string username, CancellationToken cancellationToken) {
            return Ok (await Mediator.Send (new DeleteAdminCommand { Username = username }, cancellationToken));
        }
    }
}