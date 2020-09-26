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

namespace Application.Admins.Queries {
    public class GetAllAdminQuery : IRequest<ResponsesGetDto<AdminDto>> {
        public int Pagination { get; set; }
    }

    public class GetAllAdminQueryHandler : BaseCommandHandler<GetAllAdminQueryHandler>, IRequestHandler<GetAllAdminQuery, ResponsesGetDto<AdminDto>> {
        public GetAllAdminQueryHandler (IAppDbContext context, IMapper mapper, ILogger<GetAllAdminQueryHandler> logger) : base (context, mapper, logger) { }

        public async Task<ResponsesGetDto<AdminDto>> Handle (GetAllAdminQuery request, CancellationToken cancellationToken) {
            request.Pagination = request.Pagination == 0 ? 0 : request.Pagination;
            int skip = request.Pagination * Constant.DefaultPageSize;

            var totalData = Context.Admins.ToList ().Count;

            var entity = await Context.Admins.ProjectTo<AdminDto> (Mapper.ConfigurationProvider).ToListAsync (cancellationToken);

            entity = entity.Skip (skip).Take (Constant.DefaultPageSize).ToList ();
            var Responses = new ResponsesGetDto<AdminDto> (totalData, request.Pagination, entity);

            return Responses;
        }
    }
}