using Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace Application.Common.Vm {
    public class FormCategoryVm {
        public Category Category { get; set; }
        public IFormFile ImageUrl { get; set; }
    }
}