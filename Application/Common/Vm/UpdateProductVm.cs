using Application.Common.Dtos;
using Microsoft.AspNetCore.Http;

namespace Application.Common.Vm {
    public class UpdateProductVm {
        public ProductRequestUpdateDto Product { get; set; }

        public IFormFile FileImage { get; set; }
    }
}