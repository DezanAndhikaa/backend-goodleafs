using System;
using Application.Common.Mappings;
using Domain.Entities;

namespace Application.Common.Dtos {
    public class CategoryDto : IMapFrom<Category> {

        public Guid IdCategory { get; set; }
        public string CategoryName { get; set; }
        public string PromoCode { get; set; }

    }
}