using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Dtos;
using Application.Common.Models;
using Application.Couriers.Commands.CreateCourierCommands;
using Application.Couriers.Commands.DeleteCourierCommands;
using Application.Couriers.Commands.UpdateCourierCommands;
using Application.Couriers.Queries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Api.Controllers {

    [Route ("api/[controller]")]
    public class CourierController : BaseController<CourierController> {
        public CourierController (ILogger<CourierController> logger) : base (logger) { }

        [HttpPost]
        [Produces ("application/json")]
        [ProducesResponseType (typeof (string), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<string>> CreateCourier (CreateCourierCommand command, CancellationToken cancellationToken) {
            return Ok (await Mediator.Send (command, cancellationToken));
        }

        [HttpGet ("details/{id}")]
        [Produces ("application/json")]
        [ProducesResponseType (typeof (CourierDto), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<CourierDto>> SearchCourier (Guid id, CancellationToken cancellationToken) {
            return Ok (await Mediator.Send (new GetCourierDetailQuery { Id = id }, cancellationToken));
        }

        [HttpGet ("search/{name}")]
        [Produces ("application/json")]
        [ProducesResponseType (typeof (List<CourierDto>), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<List<CourierDto>>> SearchCourierByName (string name, CancellationToken cancellationToken) {
            return Ok (await Mediator.Send (new GetCourierDetailQueryByName { Name = name }, cancellationToken));
        }

        [HttpGet]
        [Produces ("application/json")]
        [ProducesResponseType (typeof (ResponsesGetDto<CourierDto>), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<ResponsesGetDto<CourierDto>>> AllArtcile ([FromQuery] FromQueryModel queryModel, CancellationToken cancellationToken) {
            return Ok (await Mediator.Send (new GetAllCourierQuery { Pagination = queryModel.Pagination }, cancellationToken));
        }

        [HttpPut]
        [Produces ("application/json")]
        [ProducesResponseType (typeof (string), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<string>> UpdateArtcile (UpdateCourierCommand command, CancellationToken cancellationToken) {
            return Ok (await Mediator.Send (command, cancellationToken));
        }

        [HttpDelete ("{id}")]
        [Produces ("application/json")]
        [ProducesResponseType (typeof (string), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<string>> DeleteArtcile (Guid id, CancellationToken cancellationToken) {
            return Ok (await Mediator.Send (new DeleteCourierCommand { Id = id }, cancellationToken));
        }

    }
}