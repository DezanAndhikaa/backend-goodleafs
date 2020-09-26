using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities {
    public class Discounts {
        public Guid IdDiscount { get; set; }
        public string DiscountName { get; set; }
        public DateTime DiscountStart { get; set; }
        public DateTime DiscountEnd { get; set; }
        public string DiscountType { get; set; }
        public string Content { get; set; }
        public string DiscountBanner { get; set; }
        public string Voucher { get; set; }
        public List<string> Items { get; set; }
    }
}