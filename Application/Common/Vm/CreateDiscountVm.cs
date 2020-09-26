using Application.Common.Dtos;
using Microsoft.AspNetCore.Http;

namespace Application.Common.Vm {
    public class CreateDiscountVm {
        public DiscountDto Discount { get; set; }

        public IFormFile DiscountBanner { get; set; }
    }
}