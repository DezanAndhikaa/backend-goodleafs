using Application.Common.Interface;
using AutoMapper;
using Microsoft.Extensions.Logging;

namespace Application.Common.Models {

    public class BaseCommandHandler<T> {

        protected readonly IAppDbContext Context;

        protected readonly IMapper Mapper;

        protected readonly ILogger<T> Logger;

        public BaseCommandHandler (IAppDbContext context, IMapper mapper, ILogger<T> logger) {
            Context = context;
            Mapper = mapper;
            Logger = logger;
        }
    }
}