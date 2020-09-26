using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Client.Commands.BookmarkListCommands;
using Application.Client.Commands.OrderComamnds;
using Application.Client.Queries;
using Application.Common.Dtos;
using Application.Common.Models;
using Application.Users.Commands.CreateUserCommands;
using Application.Users.Commands.DeleteUserCommands;
using Application.Users.Commands.RegisterUserCommands;
using Application.Users.Commands.UpdateUserCommands;
using Application.Users.Queries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Api.Controllers {

    [Route ("api/[controller]")]
    public class ClientController : BaseController<ClientController> {
        public ClientController (ILogger<ClientController> logger) : base (logger) { }

        [HttpPost ("register")]
        [Produces ("application/json")]
        [ProducesResponseType (typeof (Guid), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<Guid>> SignupClient (RegisterUserCommand command, CancellationToken cancellationToken) {
            return Ok (await Mediator.Send (command, cancellationToken));
        }

        [HttpPost ("login")]
        [Produces ("application/json")]
        [ProducesResponseType (typeof (string), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<string>> LoginUserClient (UserLoginQuery command, CancellationToken cancellationToken) {
            return Ok (await Mediator.Send (command, cancellationToken));
        }

        [HttpGet ("product")]
        [Produces ("application/json")]
        [ProducesResponseType (typeof (string), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<string>> FetchProduct (UserLoginQuery command, CancellationToken cancellationToken) {
            return Ok (await Mediator.Send (command, cancellationToken));
        }

        [HttpGet ("discount")]
        [Produces ("application/json")]
        [ProducesResponseType (typeof (string), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<string>> DiscountProduct (CancellationToken cancellationToken) {
            return Ok (await Mediator.Send (new FetchDiscount { }, cancellationToken));
        }

        [HttpGet ("articles/s")]
        [Produces ("application/json")]
        [ProducesResponseType (typeof (ArticlesDto), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<ArticlesDto>> SearchArticles ([FromQuery] SearchArticlesQueries command, CancellationToken cancellationToken) {
            return Ok (await Mediator.Send (command, cancellationToken));
        }

        [HttpGet ("category/s")]
        [Produces ("application/json")]
        [ProducesResponseType (typeof (DiscountDto), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<DiscountDto>> SearchDiscount ([FromQuery] SearchByCategoryQueries command, CancellationToken cancellationToken) {
            return Ok (await Mediator.Send (command, cancellationToken));
        }

        [HttpGet ("product/all/n")]
        [Produces ("application/json")]
        [ProducesResponseType (typeof (List<ProductsDto>), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<List<ProductsDto>>> SearchNameProduct ([FromQuery] SearchByNameQueries command, CancellationToken cancellationToken) {
            return Ok (await Mediator.Send (command, cancellationToken));
        }

        [HttpGet ("opening")]
        [Produces ("application/json")]
        [ProducesResponseType (typeof (OpeningDataDto), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<OpeningDataDto>> FetchProductOpening (CancellationToken cancellationToken) {
            return Ok (await Mediator.Send (new FetchOpeningDataQueries { }, cancellationToken));
        }

        [HttpGet ("category")]
        [Produces ("application/json")]
        [ProducesResponseType (typeof (List<ProductsDto>), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<List<ProductsDto>>> FetchProductByCategories ([FromQuery] SearchByCategoryQueries command, CancellationToken cancellationToken) {
            return Ok (await Mediator.Send (command, cancellationToken));
        }

        [HttpPost ("bookmark")]
        [Produces ("application/json")]
        [ProducesResponseType (typeof (string), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<string>> FetchProductBookmark (BookmarkListCommand command, CancellationToken cancellationToken) {
            return Ok (await Mediator.Send (command, cancellationToken));
        }

        [HttpPost ("order")]
        [Produces ("application/json")]
        [ProducesResponseType (typeof (string), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<string>> OrderPesanan (CreateOrderCommand command, CancellationToken cancellationToken) {
            return Ok (await Mediator.Send (command, cancellationToken));
        }
    }
}