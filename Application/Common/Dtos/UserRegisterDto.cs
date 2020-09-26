using Application.Common.Mappings;
using Domain.Entities;

namespace Application.Common.Dtos {
    public class UserRegisterDto : IMapFrom<User> {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}