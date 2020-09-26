using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Admins.Commands.CreateAdminCommands;
using Application.Common.Dtos;
using Application.Common.Models;
using Application.Orders.AssignCourierCommands;
using Application.Orders.Queries;
using Application.Orders.UpdateStatusOrder;
using Application.Product.Queries;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Api.Controllers {

    [Route ("api/[controller]")]
    public class OrderController : BaseController<OrderController> {
        public OrderController (ILogger<OrderController> logger) : base (logger) { }

        [HttpPut ("assign")]
        [Produces ("application/json")]
        [ProducesResponseType (typeof (string), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<string>> AssignCourier (AssignCourierCommand command, CancellationToken cancellationToken) {
            return Ok (await Mediator.Send (command, cancellationToken));
        }

        [HttpPut ("status")]
        [Produces ("application/json")]
        [ProducesResponseType (typeof (string), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<string>> StatusOrder (UpdateStatusOrderCommand command, CancellationToken cancellationToken) {
            return Ok (await Mediator.Send (command, cancellationToken));
        }

        [HttpGet]
        [Produces ("application/json")]
        [ProducesResponseType (typeof (List<DetailOrderDataDto>), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<List<DetailOrderDataDto>>> SearchOrder ([FromQuery] SearchOrderQueries command, CancellationToken cancellationToken) {
            return Ok (await Mediator.Send (command, cancellationToken));
        }
    }
}