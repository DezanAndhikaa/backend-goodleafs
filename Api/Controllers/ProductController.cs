using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Dtos;
using Application.Common.Models;
using Application.Common.Vm;
using Application.Product.Commands.CreateProductCommands;
using Application.Product.Commands.DeleteProductCommands;
using Application.Product.Commands.UpdateDealoftheDayCommands;
using Application.Product.Commands.UpdateProductCommands;
using Application.Product.Queries;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Api.Controllers {
    [Route ("api/[controller]")]
    public class ProductController : BaseController<ProductController> {
        public ProductController (ILogger<ProductController> logger) : base (logger) { }

        [HttpPost]
        [Produces ("application/json")]
        [ProducesResponseType (typeof (string), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<string>> CreateProducts ([FromForm] CreateProductVm ProductRequest, CancellationToken cancellationToken) {
            return Ok (await Mediator.Send (new CreateProductCommand { Image = ProductRequest.FileImage, Product = ProductRequest.Product }, cancellationToken));
        }

        [HttpGet ("details/{id}")]
        [Produces ("application/json")]
        [ProducesResponseType (typeof (ProductsDto), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<ProductsDto>> SearchProduct (Guid id, CancellationToken cancellationToken) {
            return Ok (await Mediator.Send (new GetProductDetailQuery { IdProduct = id }, cancellationToken));
        }

        [HttpGet ("search/{name}")]
        [Produces ("application/json")]
        [ProducesResponseType (typeof (List<ProductsDto>), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<List<ProductsDto>>> SearchProductByName (string name, CancellationToken cancellationToken) {
            return Ok (await Mediator.Send (new GetProductDetailQueryByName { NamaProduk = name }, cancellationToken));
        }

        [HttpGet]
        [Produces ("application/json")]
        [ProducesResponseType (typeof (ResponsesGetDto<ProductsDto>), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<ResponsesGetDto<ProductsDto>>> AllProduct ([FromQuery] FromQueryModel queryModel, CancellationToken cancellationToken) {
            return Ok (await Mediator.Send (new GetAllProductQuery { Pagination = queryModel.Pagination }, cancellationToken));
        }

        [HttpGet ("DealDay")]
        [Produces ("application/json")]
        [ProducesResponseType (typeof (List<ProductsDto>), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<List<ProductsDto>>> AllProductDealoftheDay (CancellationToken cancellationToken) {
            return Ok (await Mediator.Send (new GetAllDealDayProductQueries { }, cancellationToken));
        }

        [HttpPut]
        [Produces ("application/json")]
        [ProducesResponseType (typeof (string), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<string>> UpdateProduct ([FromForm] UpdateProductVm ProductRequest, CancellationToken cancellationToken) {
            return Ok (await Mediator.Send (new UpdateProductCommand { Image = ProductRequest.FileImage, Product = ProductRequest.Product }, cancellationToken));
        }

        [HttpPut ("DealDay")]
        [Produces ("application/json")]
        [ProducesResponseType (typeof (string), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<string>> SetDealoftheDay (UpdateDealoftheDayCommand command, CancellationToken cancellationToken) {
            return Ok (await Mediator.Send (command, cancellationToken));
        }

        [HttpPut ("UnsetDealDay")]
        [Produces ("application/json")]
        [ProducesResponseType (typeof (string), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<string>> UnsetDealoftheDay (RemoveDealoftheDayCommand command, CancellationToken cancellationToken) {
            return Ok (await Mediator.Send (command, cancellationToken));
        }

        [HttpDelete ("{id}")]
        [Produces ("application/json")]
        [ProducesResponseType (typeof (List<ProductGL>), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<string>> DeleteProduct (Guid id, CancellationToken cancellationToken) {
            return Ok (await Mediator.Send (new DeleteProductCommand { IdProduct = id }, cancellationToken));
        }

        [HttpGet ("all")]
        [Produces ("application/json")]
        [ProducesResponseType (typeof (List<AllProductDto>), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<List<AllProductDto>>> AllProductWithoutPagination (CancellationToken cancellationToken) {
            return Ok (await Mediator.Send (new GetAllProductQueryWithoutPagination { }, cancellationToken));
        }
    }
}