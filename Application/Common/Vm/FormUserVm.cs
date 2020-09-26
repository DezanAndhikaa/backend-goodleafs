using Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace Application.Common.Vm {
    public class FormUserVm {
        public User User { get; set; }
        public IFormFile UserProfile { get; set; }
    }
}