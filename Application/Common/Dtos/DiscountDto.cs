using System;
using System.Collections.Generic;
using Application.Common.Mappings;
using Domain.Entities;

namespace Application.Common.Dtos {
    public class DiscountDto : IMapFrom<Discount> {
        public Guid IdDiscount { get; set; }
        public string DiscountName { get; set; }
        public DateTime DiscountStart { get; set; }
        public DateTime DiscountEnd { get; set; }
        public string DiscountType { get; set; }
        public string Content { get; set; }
        public string Voucher { get; set; }
        public string DiscountBanner { get; set; }
        public IEnumerable<string> Items { get; set; }
    }
}