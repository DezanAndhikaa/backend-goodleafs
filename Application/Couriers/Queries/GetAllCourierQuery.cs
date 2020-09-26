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

namespace Application.Couriers.Queries {
    public class GetAllCourierQuery : IRequest<ResponsesGetDto<CourierDto>> {
        public int Pagination { get; set; }
    }

    public class GetAllCourierQueryHandler : BaseCommandHandler<GetAllCourierQueryHandler>, IRequestHandler<GetAllCourierQuery, ResponsesGetDto<CourierDto>> {
        public GetAllCourierQueryHandler (IAppDbContext context, IMapper mapper, ILogger<GetAllCourierQueryHandler> logger) : base (context, mapper, logger) { }

        public async Task<ResponsesGetDto<CourierDto>> Handle (GetAllCourierQuery request, CancellationToken cancellationToken) {
            request.Pagination = request.Pagination == 0 ? 0 : request.Pagination;
            int skip = request.Pagination * Constant.DefaultPageSize;

            var totalData = Context.Couriers.ToList ().Count;

            var entity = await Context.Couriers.ProjectTo<CourierDto> (Mapper.ConfigurationProvider).ToListAsync (cancellationToken);

            entity = entity.Skip (skip).Take (Constant.DefaultPageSize).ToList ();
            var Responses = new ResponsesGetDto<CourierDto> (totalData, request.Pagination, entity);

            return Responses;
        }
    }
}