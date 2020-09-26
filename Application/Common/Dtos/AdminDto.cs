using System;
using Application.Common.Mappings;
using Domain.Entities;

namespace Application.Common.Dtos {
    public class AdminDto : IMapFrom<Admin> {
        public string Username { get; set; }
        public string Password { get; set; }

    }
}