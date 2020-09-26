using System;
using Application.Common.Mappings;
using Domain.Entities;

namespace Application.Common.Dtos {
    public class DiscountListDto : IMapFrom<Discount> {
        public Guid IdDiscount { get; set; }
        public string DiscountName { get; set; }
        public string DiscountBanner { get; set; }
    }
}