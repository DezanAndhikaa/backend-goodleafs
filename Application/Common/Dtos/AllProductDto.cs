using System;
using Application.Common.Mappings;
using Domain.Entities;

namespace Application.Common.Dtos {
    public class AllProductDto : IMapFrom<ProductGL> {
        public Guid IdProduct { get; set; }
        public string ProductName { get; set; }
    }
}