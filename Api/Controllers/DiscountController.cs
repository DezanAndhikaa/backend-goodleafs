using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Dtos;
using Application.Common.Models;
using Application.Common.Vm;
using Application.Discounts.Commands.CreateDiscountCommands;
using Application.Discounts.Commands.DeleteDiscountCommands;
using Application.Discounts.Commands.UpdateDiscountCommands;
using Application.Discounts.Queries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Api.Controllers {

    [Route ("api/[controller]")]
    public class DiscountController : BaseController<DiscountController> {
        public DiscountController (ILogger<DiscountController> logger) : base (logger) { }

        [HttpPost]
        [Produces ("application/json")]
        [ProducesResponseType (typeof (string), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<string>> CreateDiscount ([FromForm] CreateDiscountVm command, CancellationToken cancellationToken) {
            return Ok (await Mediator.Send (new CreateDiscountCommand { DiscountDto = command.Discount, DiscountBanner = command.DiscountBanner }, cancellationToken));
        }

        [HttpGet ("details/{id}")]
        [Produces ("application/json")]
        [ProducesResponseType (typeof (DiscountDto), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<DiscountDto>> SearchDiscount (Guid id, CancellationToken cancellationToken) {
            return Ok (await Mediator.Send (new GetDiscountDetailQuery { Id = id }, cancellationToken));
        }

        [HttpGet ("search/{name}")]
        [Produces ("application/json")]
        [ProducesResponseType (typeof (List<DiscountDto>), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<List<DiscountDto>>> SearchDiscountByName (string name, CancellationToken cancellationToken) {
            return Ok (await Mediator.Send (new GetDiscountDetailQueryByName { Name = name }, cancellationToken));
        }

        [HttpGet]
        [Produces ("application/json")]
        [ProducesResponseType (typeof (ResponsesGetDto<DiscountDto>), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<ResponsesGetDto<DiscountDto>>> AllArtcile ([FromQuery] FromQueryModel queryModel, CancellationToken cancellationToken) {
            return Ok (await Mediator.Send (new GetAllDiscountQuery { Pagination = queryModel.Pagination }, cancellationToken));
        }

        [HttpPut]
        [Produces ("application/json")]
        [ProducesResponseType (typeof (string), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<string>> UpdateArtcile ([FromForm] CreateDiscountVm command, CancellationToken cancellationToken) {
            return Ok (await Mediator.Send (new UpdateDiscountCommand { DiscountBanner = command.DiscountBanner, DiscountDto = command.Discount }, cancellationToken));
        }

        [HttpDelete ("{id}")]
        [Produces ("application/json")]
        [ProducesResponseType (typeof (string), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<string>> DeleteArtcile (Guid id, CancellationToken cancellationToken) {
            return Ok (await Mediator.Send (new DeleteDiscountCommand { Id = id }, cancellationToken));
        }
    }
}