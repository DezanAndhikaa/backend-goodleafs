using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Api.Controllers {
    [ApiController]
    public class BaseController<T> : ControllerBase {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator> ();

        private ILogger Logger;

        protected BaseController (ILogger<T> logger) {
            Logger = logger;
        }

    }
}