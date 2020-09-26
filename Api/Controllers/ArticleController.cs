using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Articles.Commands.CreateArticleCommands;
using Application.Articles.Commands.DeleteArticleCommands;
using Application.Articles.Commands.UpdateArticleCommands;
using Application.Common.Dtos;
using Application.Common.Models;
using Application.Common.Vm;
using Application.Product.Queries;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Api.Controllers {

    [Route ("api/[controller]")]
    public class ArticleController : BaseController<ArticleController> {
        public ArticleController (ILogger<ArticleController> logger) : base (logger) { }

        [HttpPost]
        [Produces ("application/json")]
        [ProducesResponseType (typeof (string), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<string>> CreateArticle ([FromForm] CreateArticleVm command, CancellationToken cancellationToken) {
            return Ok (await Mediator.Send (new CreateArticleCommand { Article = command.Article, ArticleBanner = command.ArticleBanner }, cancellationToken));
        }

        [HttpGet ("details/{id}")]
        [Produces ("application/json")]
        [ProducesResponseType (typeof (ArticlesDto), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<ArticlesDto>> SearchArticle (Guid id, CancellationToken cancellationToken) {
            return Ok (await Mediator.Send (new GetArticleDetailQuery { Id = id }, cancellationToken));
        }

        [HttpGet ("search/{name}")]
        [Produces ("application/json")]
        [ProducesResponseType (typeof (List<ArticlesDto>), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<List<ArticlesDto>>> SearchArticleByName (string name, CancellationToken cancellationToken) {
            return Ok (await Mediator.Send (new GetArticleDetailQueryByName { Name = name }, cancellationToken));
        }

        [HttpGet]
        [Produces ("application/json")]
        [ProducesResponseType (typeof (ResponsesGetDto<ArticlesDto>), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<ResponsesGetDto<ArticlesDto>>> AllArtcile ([FromQuery] FromQueryModel queryModel, CancellationToken cancellationToken) {
            return Ok (await Mediator.Send (new GetAllArticleQuery { Pagination = queryModel.Pagination }, cancellationToken));
        }

        [HttpPut]
        [Produces ("application/json")]
        [ProducesResponseType (typeof (string), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<string>> UpdateArtcile ([FromForm] CreateArticleVm command, CancellationToken cancellationToken) {
            return Ok (await Mediator.Send (new UpdateArticleCommand { ArticleBanner = command.ArticleBanner, Article = command.Article }, cancellationToken));
        }

        [HttpDelete ("{id}")]
        [Produces ("application/json")]
        [ProducesResponseType (typeof (string), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<string>> DeleteArtcile (Guid id, CancellationToken cancellationToken) {
            return Ok (await Mediator.Send (new DeleteArticleCommand { Id = id }, cancellationToken));
        }
    }
}