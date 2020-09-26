using System;
using Application.Common.Dtos;
using Microsoft.AspNetCore.Http;

namespace Application.Common.Vm {
    public class UpdateDiscountVm {
        public Guid DiscountId { get; set; }
        public DiscountDto Discount { get; set; }

        public IFormFile DiscountBanner { get; set; }
    }
}