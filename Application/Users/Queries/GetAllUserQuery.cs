using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Dtos;
using Application.Common.Exceptions;
using Application.Common.Interface;
using Application.Common.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Application.Users.Queries {
    public class GetAllUserQuery : IRequest<ResponsesGetDto<UserDto>> {
        public int Pagination { get; set; }
    }

    public class GetAllUserQueryHandler : BaseCommandHandler<GetAllUserQueryHandler>, IRequestHandler<GetAllUserQuery, ResponsesGetDto<UserDto>> {
        public GetAllUserQueryHandler (IAppDbContext context, IMapper mapper, ILogger<GetAllUserQueryHandler> logger) : base (context, mapper, logger) { }

        public async Task<ResponsesGetDto<UserDto>> Handle (GetAllUserQuery request, CancellationToken cancellationToken) {
            request.Pagination = request.Pagination == 0 ? 0 : request.Pagination;
            int skip = request.Pagination * Constant.DefaultPageSize;

            var totalData = Context.Users.ToList ().Count;

            var entity = await Context.Users.ProjectTo<UserDto> (Mapper.ConfigurationProvider).ToListAsync (cancellationToken);

            entity = entity.Skip (skip).Take (Constant.DefaultPageSize).ToList ();
            var Responses = new ResponsesGetDto<UserDto> (totalData, request.Pagination, entity);

            return Responses;
        }
    }
}