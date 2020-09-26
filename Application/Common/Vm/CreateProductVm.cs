using Application.Common.Dtos;
using Microsoft.AspNetCore.Http;

namespace Application.Common.Vm {
    public class CreateProductVm {
        public ProductRequestDto Product { get; set; }

        public IFormFile FileImage { get; set; }
    }
}