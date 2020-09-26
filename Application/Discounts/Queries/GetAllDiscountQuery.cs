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

namespace Application.Discounts.Queries {
    public class GetAllDiscountQuery : IRequest<ResponsesGetDto<DiscountDto>> {
        public int Pagination { get; set; }
    }

    public class GetAllDiscountQueryHandler : BaseCommandHandler<GetAllDiscountQueryHandler>, IRequestHandler<GetAllDiscountQuery, ResponsesGetDto<DiscountDto>> {
        public GetAllDiscountQueryHandler (IAppDbContext context, IMapper mapper, ILogger<GetAllDiscountQueryHandler> logger) : base (context, mapper, logger) { }

        public async Task<ResponsesGetDto<DiscountDto>> Handle (GetAllDiscountQuery request, CancellationToken cancellationToken) {
            request.Pagination = request.Pagination == 0 ? 0 : request.Pagination;
            int skip = request.Pagination * Constant.DefaultPageSize;

            var totalData = Context.Discounts.ToList ().Count;

            var entity = await Context.Discounts.ProjectTo<DiscountDto> (Mapper.ConfigurationProvider).ToListAsync (cancellationToken);

            entity = entity.Skip (skip).Take (Constant.DefaultPageSize).ToList ();
            var Responses = new ResponsesGetDto<DiscountDto> (totalData, request.Pagination, entity);

            return Responses;
        }
    }
}