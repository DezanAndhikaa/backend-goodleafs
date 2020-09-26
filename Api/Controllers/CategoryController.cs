using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Categories.Commands.CreateCategoryCommands;
using Application.Categories.Commands.DeleteCategoryCommands;
using Application.Categories.Commands.UpdateCategoryCommands;
using Application.Categories.Queries;
using Application.Common.Dtos;
using Application.Common.Models;
using Application.Common.Vm;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Api.Controllers {

    [Route ("api/[controller]")]
    public class CategoryController : BaseController<CategoryController> {
        public CategoryController (ILogger<CategoryController> logger) : base (logger) { }

        [HttpPost]
        [Produces ("application/json")]
        [ProducesResponseType (typeof (string), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<string>> CreateCategory ([FromForm] FormCategoryVm command, CancellationToken cancellationToken) {
            return Ok (await Mediator.Send (new CreateCategoryCommand { Category = command.Category, Image = command.ImageUrl }, cancellationToken));
        }

        [HttpGet ("details/{id}")]
        [Produces ("application/json")]
        [ProducesResponseType (typeof (CategoryDto), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<CategoryDto>> SearchCategory (Guid id, CancellationToken cancellationToken) {
            return Ok (await Mediator.Send (new GetCategoryDetailQuery { Id = id }, cancellationToken));
        }

        [HttpGet ("search/{name}")]
        [Produces ("application/json")]
        [ProducesResponseType (typeof (List<CategoryDto>), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<List<CategoryDto>>> SearchArticleByName (string name, CancellationToken cancellationToken) {
            return Ok (await Mediator.Send (new GetCategoryDetailQueryByName { Name = name }, cancellationToken));
        }

        [HttpGet]
        [Produces ("application/json")]
        [ProducesResponseType (typeof (ResponsesGetDto<CategoryDto>), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<ResponsesGetDto<CategoryDto>>> AllCategory ([FromQuery] FromQueryModel queryModel, CancellationToken cancellationToken) {
            return Ok (await Mediator.Send (new GetAllCategoryQuery { Pagination = queryModel.Pagination }, cancellationToken));
        }

        [HttpPut]
        [Produces ("application/json")]
        [ProducesResponseType (typeof (string), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<string>> UpdateCategory ([FromForm] FormCategoryVm command, CancellationToken cancellationToken) {
            return Ok (await Mediator.Send (new UpdateCategoryCommand { Category = command.Category, ImageUrl = command.ImageUrl }, cancellationToken));
        }

        [HttpDelete ("{id}")]
        [Produces ("application/json")]
        [ProducesResponseType (typeof (string), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<string>> DeleteCategory (Guid id, CancellationToken cancellationToken) {
            return Ok (await Mediator.Send (new DeleteCategoryCommand { Id = id }, cancellationToken));
        }
    }
}